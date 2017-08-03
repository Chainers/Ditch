using System;
using System.Globalization;

namespace Ditch
{
    public class Money
    {
        public long Value { get; }

        public string Currency { get; }

        public byte Precision { get; }

        public Money(string value) : this(value, CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.InvariantCulture.NumberFormat.NumberGroupSeparator) { }

        public Money(string value, string numberDecimalSeparator, string numberGroupSeparator)
        {
            var kv = value.Split(' ');
            Precision = (byte)(kv[0].Length - kv[0].LastIndexOf(numberDecimalSeparator, StringComparison.OrdinalIgnoreCase) - 1);
            var buf = kv[0]
                .Replace(numberDecimalSeparator, string.Empty)
                .Replace(numberGroupSeparator, string.Empty);
            Value = long.Parse(buf);
            Currency = kv[1].ToUpper();
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

        public static implicit operator Money(string value)
        {
            return new Money(value);
        }

        public static implicit operator string(Money value)
        {
            return value.ToString();
        }

        public override string ToString()
        {
            return ToString(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
        }

        public string ToString(string numberDecimalSeparator)
        {
            var dig = Value.ToString();
            if (dig.Length <= Precision)
            {
                var prefix = new string('0', Precision - dig.Length + 1);
                dig = prefix + dig;
            }
            dig = dig.Insert(dig.Length - Precision, numberDecimalSeparator);
            return $"{dig} {Currency}";
        }
    }
}
