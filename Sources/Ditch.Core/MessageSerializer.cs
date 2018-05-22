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
            if (type == typeof(String))
            {
                var typed = (string)val;
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
            if (val is ICustomSerializer customSerializer)
            {
                customSerializer.Serializer(stream, this);
                return;
            }
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
        protected byte[] VarInt(int n)
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