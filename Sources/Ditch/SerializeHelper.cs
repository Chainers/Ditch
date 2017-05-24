using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Ditch
{
    public class SerializeHelper
    {
        public class IgnoreForMessageAttribute : Attribute { }

        public static byte[] TransactionToMessage(Transaction transaction)
        {
            using (var ms = new MemoryStream())
            {
                var props = typeof(Transaction).GetProperties();
                foreach (var prop in props)
                {
                    if (prop.GetCustomAttribute<IgnoreForMessageAttribute>() != null)
                        continue;
                    AddToMessageStream(ms, prop, transaction);
                }
                return ms.ToArray();
            }
        }

        private static void AddToMessageStream(Stream stream, PropertyInfo info, object obj)
        {
            var type = info.PropertyType;
            var val = info.GetValue(obj);

            switch (type.Name)
            {
                case "UInt16":
                    {
                        var buf = BitConverter.GetBytes((UInt16)val);
                        stream.Write(buf, 0, buf.Length);
                        break;
                    }
                case "UInt32":
                    {
                        var buf = BitConverter.GetBytes((UInt32)val);
                        stream.Write(buf, 0, buf.Length);
                        break;
                    }
                case "DateTime":
                    {
                        var buf = BitConverter.GetBytes((Int32)(((DateTime)val).Ticks / 10000000 - 62135596800)); // 01.01.1970
                        stream.Write(buf, 0, buf.Length);
                        break;
                    }
                case "Byte[]":
                    {
                        var buf = (byte[])val;
                        stream.Write(buf, 0, buf.Length);
                        break;
                    }
                case "OperationType":
                    {
                        stream.WriteByte((byte)val);
                        break;
                    }
                case "String":
                    {
                        var typed = (string)val;
                        var buf = ConvertHelper.VarInt(typed.Length);
                        stream.Write(buf, 0, buf.Length);
                        buf = Encoding.UTF8.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        break;
                    }
                case "BaseOperation[]":
                    {
                        var operations = (BaseOperation[])val;
                        if (operations == null)
                            break;
                        var buf = ConvertHelper.VarInt(operations.Length);
                        stream.Write(buf, 0, buf.Length);
                        foreach (var operation in operations)
                        {
                            var chType = operation.GetType();
                            var properties = chType.GetProperties();
                            foreach (var prop in properties)
                            {
                                if (prop.GetCustomAttribute<IgnoreForMessageAttribute>() != null)
                                    continue;
                                AddToMessageStream(stream, prop, operation);
                            }
                        }
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }
    }
}