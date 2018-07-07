using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Ditch.Core.Attributes;
using Ditch.Core.Interfaces;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Core
{
    public class MessageSerializer : IMessageSerializer
    {
        public byte[] Serialize<T>(object obj)
        {
            using (var ms = new MemoryStream())
            {
                Serialize<T>(ms, obj);
                return ms.ToArray();
            }
        }

        public void Serialize<T>(Stream ms, object obj)
        {
            var props = GetPropertiesForMessage(typeof(T));
            foreach (var prop in props)
            {
                AddToMessageStream(ms, prop, obj);
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

                        var buflen = new UnsignedInt((uint)buf.Length);
                        buflen.Serializer(stream, this);

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

                            var buf = new UnsignedInt((uint)typed.Count);
                            buf.Serializer(stream, this);

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

            var order = prop.GetCustomAttribute<JsonPropertyAttribute>();
            if (order?.NullValueHandling == NullValueHandling.Ignore)
            {
                if (inval == null)
                {
                    stream.WriteByte(0);
                    return;
                }

                stream.WriteByte(1);
            }

            AddToMessageStream(stream, intype, inval);
        }
    }
}