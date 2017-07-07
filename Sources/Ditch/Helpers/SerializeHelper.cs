using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Ditch.Operations;
using Ditch.Operations.Post;

namespace Ditch.Helpers
{
    internal class SerializeHelper
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class MessageOrderAttribute : Attribute
        {
            public readonly int Value;

            public MessageOrderAttribute(int value)
            {
                Value = value;
            }
        }

        public static IEnumerable<PropertyInfo> GetPropertiesForMessage(Type type)
        {
            var props = type.GetRuntimeProperties();
            var kvarray = new List<KeyValuePair<int, PropertyInfo>>();
            foreach (var prop in props)
            {
                var order = prop.GetCustomAttribute<MessageOrderAttribute>();
                if (order != null)
                {
                    kvarray.Add(new KeyValuePair<int, PropertyInfo>(order.Value, prop));
                }
            }

            return kvarray.OrderBy(i => i.Key).Select(p => p.Value);
        }

        public static byte[] TransactionToMessage(Transaction transaction)
        {
            using (var ms = new MemoryStream())
            {
                var props = GetPropertiesForMessage(typeof(Transaction));
                foreach (var prop in props)
                {
                    var type = prop.PropertyType;
                    var val = prop.GetValue(transaction);
                    AddToMessageStream(ms, type, val);
                }
                return ms.ToArray();
            }
        }

        private static void AddToMessageStream(Stream stream, Type type, object val)
        {
            if (type == typeof(bool))
            {
                stream.WriteByte((byte)((bool)val ? 1 : 0));
                return;
            }
            if (type == typeof(byte))
            {
                stream.WriteByte((byte)val);
                return;
            }
            if (type == typeof(Int16))
            {
                var buf = BitConverter.GetBytes((Int16)val);
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(UInt16))
            {
                var buf = BitConverter.GetBytes((UInt16)val);
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(Int32))
            {
                var buf = BitConverter.GetBytes((Int32)val);
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(UInt32))
            {
                var buf = BitConverter.GetBytes((UInt32)val);
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(Int64))
            {
                var buf = BitConverter.GetBytes((Int64)val);
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(UInt64))
            {
                var buf = BitConverter.GetBytes((UInt64)val);
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(float))
            {
                var buf = BitConverter.GetBytes((float)val);
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(double))
            {
                var buf = BitConverter.GetBytes((double)val);
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(DateTime))
            {
                var buf = BitConverter.GetBytes((Int32)(((DateTime)val).Ticks / 10000000 - 62135596800)); // 01.01.1970
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(Byte[]))
            {
                var buf = (byte[])val;
                stream.Write(buf, 0, buf.Length);
                return;
            }
            if (type == typeof(OperationType))
            {
                stream.WriteByte((byte)val);
                return;
            }
            if (type == typeof(Money))
            {
                var typed = (Money)val;
                var buf = BitConverter.GetBytes(typed.Value);
                stream.Write(buf, 0, buf.Length);
                stream.WriteByte(typed.Precision);
                buf = Encoding.UTF8.GetBytes(typed.Currency);
                stream.Write(buf, 0, buf.Length);
                for (var i = buf.Length; i < 7; i++)
                    stream.WriteByte(0);
                return;
            }
            if (type == typeof(String))
            {
                var typed = (string)val;
                if (string.IsNullOrEmpty(typed))
                {
                    stream.WriteByte(0);
                    return;
                }
                var buf = ConvertHelper.VarInt(typed.Length);
                stream.Write(buf, 0, buf.Length);
                buf = Encoding.UTF8.GetBytes(typed);
                stream.Write(buf, 0, buf.Length);
                return;
            }

            if (type.IsArray)
            {
                var typed = (ICollection)val;
                if (typed == null)
                    return;
                var buf = ConvertHelper.VarInt(typed.Count);
                stream.Write(buf, 0, buf.Length);
                foreach (var value in typed)
                {
                    AddToMessageStream(stream, value.GetType(), value);
                }
                return;
            }
            if (val is BaseOperation)
            {
                var chType = val.GetType();
                var properties = GetPropertiesForMessage(chType);
                foreach (var prop in properties)
                {
                    var intype = prop.PropertyType;
                    var inval = prop.GetValue(val);
                    AddToMessageStream(stream, intype, inval);
                }
                return;
            }
            if (val is INamedConteiner)
            {
                var chType = val.GetType();
                var properties = GetPropertiesForMessage(chType);
                foreach (var prop in properties)
                {
                    var intype = prop.PropertyType;
                    var inval = prop.GetValue(val);
                    AddToMessageStream(stream, intype, inval);
                }
                return;
            }
            throw new NotImplementedException();

        }
    }
}