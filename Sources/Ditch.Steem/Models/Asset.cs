using System;
using System.Globalization;
using System.IO;
using System.Text;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem.Models
{
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class Asset : ICustomJson, ICustomSerializer
    {
        private int _type;

        private string Value { get; set; }

        private string Amount { get; set; }

        private AssetSymbolType Symbol { get; set; }


        public Asset(int verison, int amount, uint assetNum)
        {
            Amount = amount.ToString();
            Symbol = new AssetSymbolType(assetNum);

            if (verison >= 0x00001304)
            {
                _type = 2;
            }
            else
            {
                _type = 1;

                var dig = amount.ToString();
                var precision = Symbol.Decimals();
                if (precision > 0)
                {
                    if (dig.Length <= precision)
                    {
                        var prefix = new string('0', precision - dig.Length + 1);
                        dig = prefix + dig;
                    }
                    dig = dig.Insert(dig.Length - precision, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
                }

                string currency;
                switch (assetNum)
                {
                    case Config.SteemAssetNumSbd:
                        {
                            currency = "SBD";
                            break;
                        }
                    case Config.SteemAssetNumSteem:
                        {
                            currency = "STEEM";
                            break;
                        }
                    case Config.SteemAssetNumVests:
                        {
                            currency = "VESTS";
                            break;
                        }
                    default:
                        throw new InvalidCastException();
                }

                Value = string.IsNullOrEmpty(currency) ? dig : $"{dig} {currency}";
            }
        }

        public Asset() { }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                Value = reader.Value.ToString();
                _type = 1;
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                var obj = serializer.Deserialize<JObject>(reader);
                Amount = obj.Value<string>("amount");
                Symbol = new AssetSymbolType(obj.Value<string>("nai"), obj.Value<byte>("precision"));
                _type = 2;
            }
            else
            {
                var arr = serializer.Deserialize<JArray>(reader);
                Amount = arr[0].Value<string>("amount");
                Symbol = new AssetSymbolType(arr[2].Value<string>("nai"), arr[1].Value<byte>("precision"));
                _type = 3;
            }
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            switch (_type)
            {
                case 1:
                    {
                        writer.WriteValue(Value);
                        break;
                    }
                case 2:
                    {
                        writer.WriteStartObject();

                        writer.WritePropertyName("amount");
                        writer.WriteValue(Amount);

                        writer.WritePropertyName("precision");
                        writer.WriteValue(Symbol.Decimals());

                        writer.WritePropertyName("nai");
                        writer.WriteValue(Symbol.ToNaiString());

                        writer.WriteEndObject();
                        break;
                    }
                case 3:
                    {
                        writer.WriteStartArray();

                        writer.WriteValue(Amount);
                        writer.WriteValue(Symbol.Decimals());
                        writer.WriteValue(Symbol.ToNaiString());

                        writer.WriteEndArray();
                        break;
                    }
            }

        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {

            switch (_type)
            {
                case 1:
                    {
                        SerializerFromString(stream, Value, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator);
                        break;
                    }
                case 2:
                case 3:
                    {
                        serializeHelper.AddToMessageStream(stream, typeof(long), long.Parse(Amount));
                        Symbol.Serializer(stream, serializeHelper);
                        break;
                    }
                default:
                    throw new InvalidCastException();
            }

        }

        private void SerializerFromString(Stream stream, string value, string numberDecimalSeparator, string numberGroupSeparator)
        {
            var kv = value.Split(' ');

            var args = kv[0]
                .Replace(numberDecimalSeparator, string.Empty)
                .Replace(numberGroupSeparator, string.Empty);

            var amount = long.Parse(args);
            var buf = BitConverter.GetBytes(amount);
            stream.Write(buf, 0, buf.Length);

            byte precision = 0;
            var charLenAftSeparator = kv[0].LastIndexOf(numberDecimalSeparator, StringComparison.OrdinalIgnoreCase);
            if (charLenAftSeparator > 0)
                precision = (byte)(buf.Length - charLenAftSeparator);

            stream.WriteByte(precision);

            var currency = kv[1].ToUpper();
            buf = Encoding.UTF8.GetBytes(currency);
            stream.Write(buf, 0, buf.Length);
            for (var i = buf.Length; i < 7; i++)
                stream.WriteByte(0);
        }

        #endregion
    }
}
