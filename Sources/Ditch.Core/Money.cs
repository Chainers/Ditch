using System;
using System.Globalization;

namespace Ditch.Core
{
    public class Money : IComparable<Money>, IEquatable<Money>
    {
        public long Value { get; }

        public string Currency { get; }

        public byte Precision { get; }

        public Money(string value) : this(value, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator) { }

        public Money(string value, string numberDecimalSeparator, string numberGroupSeparator)
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

        public Money(long value, byte precision, string currency)
        {
            Value = value;
            Currency = currency.ToUpper();
            Precision = precision;
        }

        public static Money operator +(Money money1, Money money2)
        {
            if (money1.Currency.Equals(money2.Currency))
            {
                if (money1.Precision > money2.Precision)
                {
                    var buf = money2.Value * (10 ^ (money1.Precision - money2.Precision));
                    return new Money(money1.Value + buf, money1.Precision, money1.Currency);
                }
                if (money1.Precision < money2.Precision)
                {
                    var buf = money1.Value * (10 ^ (money2.Precision - money1.Precision));
                    return new Money(buf + money2.Value, money2.Precision, money1.Currency);
                }
                return new Money(money1.Value + money2.Value, money1.Precision, money1.Currency);
            }
            throw new ArithmeticException("Attempt adding values with different Currency type.");
        }

        public static Money operator -(Money money1, Money money2)
        {
            if (money1.Currency.Equals(money2.Currency))
            {
                if (money1.Precision > money2.Precision)
                {
                    var buf = money2.Value * (10 ^ (money1.Precision - money2.Precision));
                    return new Money(money1.Value - buf, money1.Precision, money1.Currency);
                }
                if (money1.Precision < money2.Precision)
                {
                    var buf = money1.Value * (10 ^ (money2.Precision - money1.Precision));
                    return new Money(buf - money2.Value, money2.Precision, money1.Currency);
                }
                return new Money(money1.Value - money2.Value, money1.Precision, money1.Currency);
            }

            throw new ArithmeticException("Attempt subtract values with different Currency type.");
        }


        public static bool operator >(Money money1, Money money2)
        {
            return CompareTo(money1, money2) > 0;
        }

        public static bool operator >=(Money money1, Money money2)
        {
            return CompareTo(money1, money2) >= 0;
        }

        public static bool operator <(Money money1, Money money2)
        {
            return CompareTo(money1, money2) < 0;
        }

        public static bool operator <=(Money money1, Money money2)
        {
            return CompareTo(money1, money2) <= 0;
        }

        public static bool operator ==(Money money1, Money money2)
        {
            return CompareTo(money1, money2) == 0;
        }

        public static bool operator !=(Money money1, Money money2)
        {
            return CompareTo(money1, money2) != 0;
        }


        public static implicit operator Money(string value)
        {
            return new Money(value);
        }

        public static implicit operator Money(double value)
        {
            return new Money(value.ToString(CultureInfo.InvariantCulture));
        }

        public static implicit operator string(Money value)
        {
            return value.ToString();
        }

        public int CompareTo(Money other)
        {
            return CompareTo(this, other);
        }

        public static int CompareTo(Money first, Money other)
        {
            if (!string.IsNullOrEmpty(first.Currency) && !string.IsNullOrEmpty(other.Currency) && !first.Currency.Equals(other.Currency, StringComparison.OrdinalIgnoreCase))
                throw new InvalidCastException($"Invalid compare {first} and {other}");

            if (other.Value == first.Value && other.Precision == first.Precision)
                return 0;

            var dThis = first.Value / Math.Pow(10, first.Precision);
            var dOther = other.Value / Math.Pow(10, other.Precision);
            return dThis.CompareTo(dOther);
        }

        public bool Equals(Money other)
        {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Money)obj);
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

        public override string ToString()
        {
            return ToString(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
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
    }
}
