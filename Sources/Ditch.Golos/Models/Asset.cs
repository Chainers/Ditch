using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class Asset : ICustomJson, ICustomSerializer
    {
        private static readonly Regex MultyZeroRegex = new Regex("^0{2,}");

        public NumberFormatInfo NumberFormat { get; set; } = CultureInfo.InvariantCulture.NumberFormat;


        public long Amount { get; private set; }

        public byte Decimals { get; private set; }

        public string Currency { get; private set; }



        public Asset() { }

        public Asset(string value)
        {
            InitFromString(value);
        }

        public Asset(long amount, byte decimals, string currency)
        {
            Amount = amount;
            Currency = currency.ToUpper();
            Decimals = decimals;
        }


        public override string ToString()
        {
            var dig = ToDoubleString();
            return string.IsNullOrEmpty(Currency) ? dig : $"{dig} {Currency}";
        }

        public void InitFromString(string value)
        {
            value = MultyZeroRegex.Replace(value, "0");
            var kv = value.Split(' ');

            var buf = kv[0]
                .Replace(NumberFormat.NumberDecimalSeparator, string.Empty)
                .Replace(NumberFormat.NumberGroupSeparator, string.Empty);

            var charLenAftSeparator = kv[0].LastIndexOf(NumberFormat.NumberDecimalSeparator, StringComparison.OrdinalIgnoreCase);
            if (charLenAftSeparator > 0)
                Decimals = (byte)(buf.Length - charLenAftSeparator);
            Amount = long.Parse(buf);
            Currency = kv.Length > 1 ? kv[1].ToUpper() : string.Empty;
        }

        public string ToDoubleString()
        {
            var dig = Amount.ToString();
            if (Decimals > 0)
            {
                if (dig.Length <= Decimals)
                {
                    var prefix = new string('0', Decimals - dig.Length + 1);
                    dig = prefix + dig;
                }
                dig = dig.Insert(dig.Length - Decimals, NumberFormat.NumberDecimalSeparator);
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
            var value = reader.Value.ToString();
            InitFromString(value);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            var value = ToString();
            writer.WriteValue(value);
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var buf = BitConverter.GetBytes(Amount);
            stream.Write(buf, 0, buf.Length);

            stream.WriteByte(Decimals);

            buf = Encoding.UTF8.GetBytes(Currency);
            stream.Write(buf, 0, buf.Length);
            for (var i = buf.Length; i < 7; i++)
                stream.WriteByte(0);
        }

        #endregion

    }
}
