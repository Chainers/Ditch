using System;

namespace Ditch
{
    public struct Money
    {
        public long Value { get; private set; }

        public string Currency { get; private set; }

        public byte Precision { get; private set; }

        public Money(string value)
        {
            var kv = value.Split(' ');
            Precision = (byte)(kv[0].Length - kv[0].LastIndexOf(GlobalSettings.ChainInfo.ServerCultureInfo.NumberFormat.NumberDecimalSeparator, StringComparison.OrdinalIgnoreCase) - 1);
            var buf = kv[0]
                .Replace(GlobalSettings.ChainInfo.ServerCultureInfo.NumberFormat.NumberDecimalSeparator, string.Empty)
                .Replace(GlobalSettings.ChainInfo.ServerCultureInfo.NumberFormat.NumberGroupSeparator, string.Empty);
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
            var dig = Value.ToString();
            if (dig.Length <= Precision)
            {
                var prefix = new string('0', Precision - dig.Length + 1);
                dig = prefix + dig;
            }
            dig = dig.Insert(dig.Length - Precision, GlobalSettings.ChainInfo.ServerCultureInfo.NumberFormat.NumberDecimalSeparator);
            return $"{dig} {Currency}";
        }
    }
}
