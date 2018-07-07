using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
        private static readonly Regex MultyZeroRegex = new Regex("^0{2,}");

        public NumberFormatInfo NumberFormat { get; set; } = CultureInfo.InvariantCulture.NumberFormat;

        private byte _type;


        public long Amount { get; private set; }

        public AssetSymbolType Symbol { get; private set; }


        public Asset() { }

        public Asset(long amount, uint assetNum)
        {
            FromNewFormat(amount, assetNum);
        }


        public void FromNewFormat(long amount, uint assetNum)
        {
            Amount = amount;
            Symbol = new AssetSymbolType(assetNum);
        }

        public void FromOldFormat(string asset)
        {
            asset = MultyZeroRegex.Replace(asset, "0");
            var args = asset.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (args.Length != 2)
                throw new InvalidCastException($"Error cast {asset} to Asset");

            switch (args[1])
            {
                case "SBD":
                    Symbol = new AssetSymbolType(Config.SteemAssetNumSbd);
                    break;
                case "STEEM":
                    Symbol = new AssetSymbolType(Config.SteemAssetNumSteem);
                    break;
                case "VESTS":
                    Symbol = new AssetSymbolType(Config.SteemAssetNumVests);
                    break;
                default:
                    throw new InvalidCastException($"Error cast {asset} to Asset");
            }

            var val = args[0].Replace(NumberFormat.NumberGroupSeparator, "");
            var dec = val.IndexOf(NumberFormat.NumberDecimalSeparator, StringComparison.Ordinal);

            string amount;
            if (dec > -1)
            {
                dec = val.Length - dec - 1;
                if (dec > Symbol.Decimals())
                    throw new InvalidCastException($"Error cast {asset} to Asset");

                amount = val.Replace(NumberFormat.NumberDecimalSeparator, "");
                if (dec != Symbol.Decimals())
                {
                    amount += new string('0', Symbol.Decimals() - dec);
                }
            }
            else
            {
                amount = val + new string('0', Symbol.Decimals());
            }

            Amount = long.Parse(amount);
        }



        public string ToOldFormatString()
        {
            var dig = ToDoubleString();

            string currency;
            switch (Symbol.AssetNum)
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

            return string.IsNullOrEmpty(currency) ? dig : $"{dig} {currency}";
        }

        public string ToDoubleString()
        {
            var dig = Amount.ToString();
            var precision = Symbol.Decimals();
            if (precision > 0)
            {
                if (dig.Length <= precision)
                {
                    var prefix = new string('0', precision - dig.Length + 1);
                    dig = prefix + dig;
                }
                dig = dig.Insert(dig.Length - precision, NumberFormat.NumberDecimalSeparator);
            }

            return dig;
        }
        
        public double ToDouble()
        {
            return double.Parse(ToDoubleString());
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var val = reader.Value.ToString();
                FromOldFormat(val);
                _type = 1;
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                var obj = serializer.Deserialize<JObject>(reader);
                Amount = long.Parse(obj.Value<string>("amount"));
                Symbol = new AssetSymbolType(obj.Value<string>("nai"), obj.Value<byte>("precision"));
                _type = 2;
            }
            else
            {
                var arr = serializer.Deserialize<JArray>(reader);
                Amount = long.Parse(arr[0].Value<string>("amount"));
                Symbol = new AssetSymbolType(arr[2].Value<string>("nai"), arr[1].Value<byte>("precision"));
                _type = 3;
            }
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            switch (_type)
            {
                case 0 when Config.BlockchainVersion < 0x00001304:
                case 1:
                    {
                        writer.WriteValue(ToOldFormatString());
                        break;
                    }
                case 0 when Config.BlockchainVersion >= 0x00001304:
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

                default:
                    throw new NotImplementedException();
            }

        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            switch (_type)
            {
                case 0 when Config.BlockchainVersion < 0x00001304:
                case 1:
                    {
                        serializeHelper.AddToMessageStream(stream, typeof(long), Amount);
                        stream.WriteByte(Symbol.Decimals());
                        string currency;
                        switch (Symbol.AssetNum)
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

                        var buf = Encoding.UTF8.GetBytes(currency);
                        stream.Write(buf, 0, buf.Length);
                        for (var i = buf.Length; i < 7; i++)
                            stream.WriteByte(0);

                        break;
                    }
                case 0 when Config.BlockchainVersion >= 0x00001304:
                case 2:
                case 3:
                    {
                        serializeHelper.AddToMessageStream(stream, typeof(long), Amount);
                        Symbol.Serializer(stream, serializeHelper);
                        break;
                    }
                default:
                    throw new InvalidCastException();
            }

        }

        #endregion
    }
}
