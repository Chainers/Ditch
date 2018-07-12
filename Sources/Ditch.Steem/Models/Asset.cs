using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Asset : ICustomSerializer
    {
        private static readonly Regex MultyZeroRegex = new Regex("^0{2,}");

        public NumberFormatInfo NumberFormat { get; set; } = CultureInfo.InvariantCulture.NumberFormat;


        public long Amount { get; private set; }

        public AssetSymbolType Symbol { get; private set; }


        public Asset()
        {
        }

        public Asset(long amount, uint assetNum)
        {
            Amount = amount;
            Symbol = new AssetSymbolType(assetNum);
        }


        public void FromNewFormat(long amount, byte decimalPlaces, string value)
        {
            Amount = amount;
            Symbol = new AssetSymbolType(decimalPlaces, value);
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


        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            serializeHelper.AddToMessageStream(stream, typeof(long), Amount);
            Symbol.Serializer(stream, serializeHelper);
        }

        #endregion
    }
}