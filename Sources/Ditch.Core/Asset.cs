using System;
using System.Globalization;
using Newtonsoft.Json;
using Ditch.Core.Helpers;

namespace Ditch.Core
{
    [JsonConverter(typeof(ToStringConverter))]
    public partial class Asset : IComparable<Asset>, IEquatable<Asset>, IComplexString
    {
        public long Value { get; private set; }

        public string Currency { get; private set; }

        public byte Precision { get; private set; }


        public Asset() { }

        public Asset(string value) { InitFromString(value); }

        public Asset(string value, string numberDecimalSeparator, string numberGroupSeparator)
        {
            InitFromString(value, numberDecimalSeparator, numberGroupSeparator);
        }

        public Asset(long value, byte precision, string currency)
        {
            Value = value;
            Currency = currency.ToUpper();
            Precision = precision;
        }


        public static Asset operator +(Asset asset1, Asset asset2)
        {
            if (asset1.Currency.Equals(asset2.Currency))
            {
                if (asset1.Precision > asset2.Precision)
                {
                    var buf = asset2.Value * (10 ^ (asset1.Precision - asset2.Precision));
                    return new Asset(asset1.Value + buf, asset1.Precision, asset1.Currency);
                }
                if (asset1.Precision < asset2.Precision)
                {
                    var buf = asset1.Value * (10 ^ (asset2.Precision - asset1.Precision));
                    return new Asset(buf + asset2.Value, asset2.Precision, asset1.Currency);
                }
                return new Asset(asset1.Value + asset2.Value, asset1.Precision, asset1.Currency);
            }
            throw new ArithmeticException("Attempt adding values with different Currency type.");
        }

        public static Asset operator -(Asset asset1, Asset asset2)
        {
            if (asset1.Currency.Equals(asset2.Currency))
            {
                if (asset1.Precision > asset2.Precision)
                {
                    var buf = asset2.Value * (10 ^ (asset1.Precision - asset2.Precision));
                    return new Asset(asset1.Value - buf, asset1.Precision, asset1.Currency);
                }
                if (asset1.Precision < asset2.Precision)
                {
                    var buf = asset1.Value * (10 ^ (asset2.Precision - asset1.Precision));
                    return new Asset(buf - asset2.Value, asset2.Precision, asset1.Currency);
                }
                return new Asset(asset1.Value - asset2.Value, asset1.Precision, asset1.Currency);
            }

            throw new ArithmeticException("Attempt subtract values with different Currency type.");
        }


        public static bool operator >(Asset asset1, Asset asset2)
        {
            return CompareTo(asset1, asset2) > 0;
        }

        public static bool operator >=(Asset asset1, Asset asset2)
        {
            return CompareTo(asset1, asset2) >= 0;
        }

        public static bool operator <(Asset asset1, Asset asset2)
        {
            return CompareTo(asset1, asset2) < 0;
        }

        public static bool operator <=(Asset asset1, Asset asset2)
        {
            return CompareTo(asset1, asset2) <= 0;
        }

        public static bool operator ==(Asset asset1, Asset asset2)
        {
            return CompareTo(asset1, asset2) == 0;
        }

        public static bool operator !=(Asset asset1, Asset asset2)
        {
            return CompareTo(asset1, asset2) != 0;
        }


        public static implicit operator Asset(string value)
        {
            return new Asset(value);
        }

        public static implicit operator Asset(double value)
        {
            return new Asset(value.ToString(CultureInfo.InvariantCulture));
        }

        public static implicit operator string(Asset value)
        {
            return value.ToString();
        }

        public int CompareTo(Asset other)
        {
            return CompareTo(this, other);
        }

        public static int CompareTo(Asset first, Asset other)
        {
            if (!string.IsNullOrEmpty(first.Currency) && !string.IsNullOrEmpty(other.Currency) && !first.Currency.Equals(other.Currency, StringComparison.OrdinalIgnoreCase))
                throw new InvalidCastException($"Invalid compare {first} and {other}");

            if (other.Value == first.Value && other.Precision == first.Precision)
                return 0;

            var dThis = first.Value / Math.Pow(10, first.Precision);
            var dOther = other.Value / Math.Pow(10, other.Precision);
            return dThis.CompareTo(dOther);
        }

        public bool Equals(Asset other)
        {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Asset)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Value.GetHashCode();
                hashCode = (hashCode * 397) ^ (Currency != null ? Currency.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Precision.GetHashCode();
                return hashCode;
            }
        }

        public string ToString(string numberDecimalSeparator)
        {
            var dig = Value.ToString();
            if (Precision > 0)
            {
                if (dig.Length <= Precision)
                {
                    var prefix = new string('0', Precision - dig.Length + 1);
                    dig = prefix + dig;
                }
                dig = dig.Insert(dig.Length - Precision, numberDecimalSeparator);
            }
            return string.IsNullOrEmpty(Currency) ? dig : $"{dig} {Currency}";
        }

        public double ToDouble()
        {
            return Value / Math.Pow(10, Precision);
        }


        #region ToStringConverter

        public void InitFromString(string value)
        {
            InitFromString(value, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator);
        }

        public void InitFromString(string value, string numberDecimalSeparator, string numberGroupSeparator)
        {
            var kv = value.Split(' ');

            var buf = kv[0]
                .Replace(numberDecimalSeparator, string.Empty)
                .Replace(numberGroupSeparator, string.Empty);

            var charLenAftSeparator = kv[0].LastIndexOf(numberDecimalSeparator, StringComparison.OrdinalIgnoreCase);
            if (charLenAftSeparator > 0)
                Precision = (byte)(buf.Length - charLenAftSeparator);
            Value = long.Parse(buf);
            Currency = kv.Length > 1 ? kv[1].ToUpper() : string.Empty;
        }

        public override string ToString()
        {
            return ToString(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
        }

        #endregion ToStringConverter
    }
}
