using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Ditch.Core.Attributes;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Core
{
    public class MessageSerializer : IMessageSerializer
    {
        public byte[] Serialize<T>(object obj)
        {
            using (var ms = new MemoryStream())
            {
                var props = GetPropertiesForMessage(typeof(T));
                foreach (var prop in props)
                {
                    AddToMessageStream(ms, prop, obj);
                }
                return ms.ToArray();
            }
        }

        public virtual void AddToMessageStream(Stream stream, Type type, object val)
        {
            switch (val)
            {
                case bool typed:
                    {
                        stream.WriteByte((byte)(typed ? 1 : 0));
                        return;
                    }
                case byte typed:
                    {
                        stream.WriteByte(typed);
                        return;
                    }
                case short typed:
                    {
                        var buf = BitConverter.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case ushort typed:
                    {
                        var buf = BitConverter.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case int typed:
                    {
                        var buf = BitConverter.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case uint typed:
                    {
                        var buf = BitConverter.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case long typed:
                    {
                        var buf = BitConverter.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case ulong typed:
                    {
                        var buf = BitConverter.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case float typed:
                    {
                        var buf = BitConverter.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case double typed:
                    {
                        var buf = BitConverter.GetBytes(typed);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case DateTime typed:
                    {
                        var buf = BitConverter.GetBytes((int)(typed.Ticks / 10000000 - 62135596800)); // 01.01.1970
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case byte[] typed:
                    {
                        stream.Write(typed, 0, typed.Length);
                        return;
                    }
                case string typed:
                    {
                        if (string.IsNullOrEmpty(typed))
                        {
                            stream.WriteByte(0);
                            return;
                        }
                        var buf = Encoding.UTF8.GetBytes(typed);
                        var buflen = VarInt(buf.Length);
                        stream.Write(buflen, 0, buflen.Length);
                        stream.Write(buf, 0, buf.Length);
                        return;
                    }
                case ICustomSerializer typed:
                    {
                        typed.Serializer(stream, this);
                        return;
                    }
                default:
                    {
                        if (type.IsEnum)
                        {
                            stream.WriteByte((byte)val);
                            return;
                        }
                        if (type.IsArray)
                        {
                            var typed = (ICollection)val;
                            if (typed == null)
                                return;
                            var buf = VarInt(typed.Count);
                            stream.Write(buf, 0, buf.Length);
                            foreach (var value in typed)
                            {
                                AddToMessageStream(stream, value.GetType(), value);
                            }
                            return;
                        }
                        if (type.IsClass)
                        {
                            var chType = val.GetType();
                            var properties = GetPropertiesForMessage(chType);
                            foreach (var prop in properties)
                            {
                                AddToMessageStream(stream, prop, val);
                            }
                            return;
                        }
                        throw new NotImplementedException();
                    }
            }
        }

        protected IEnumerable<PropertyInfo> GetPropertiesForMessage(Type type)
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

        protected void AddToMessageStream(Stream stream, PropertyInfo prop, object val)
        {
            var intype = prop.PropertyType;
            var inval = prop.GetValue(val);

            if (inval == null)
            {
                var order = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (order?.NullValueHandling == NullValueHandling.Ignore)
                {
                    stream.WriteByte(0);
                    return;
                }
            }

            AddToMessageStream(stream, intype, inval);
        }

        /// <summary>
        /// Сonverts a number to a minimal byte array
        /// *peeped  https://github.com/xeroc/python-graphenelib/blob/master/graphenebase/types.py
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static byte[] VarInt(int n)
        {
            //get array len
            var i = 1;
            var k = n;
            while (k >= 0x80)
            {
                k >>= 7;
                i++;
            }

            var data = new byte[i];
            i = 0;

            while (n >= 0x80)
            {
                data[i++] = (byte)(0x80 | (n & 0x7f));
                n >>= 7;
            }

            data[i] += (byte)n;
            return data;
        }
    }
}