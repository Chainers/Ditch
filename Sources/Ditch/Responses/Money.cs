using System;

namespace Ditch.Responses
{
    public struct Money
    {
        public double Value { get; set; }
        public string Currency { get; set; }



        public Money(string value)
        {
            var kv = value.Split(' ');
            Value = double.Parse(kv[0], OperationManager.ChainInfo.ServerCultureInfo);
            Currency = kv[1].ToUpper();
        }

        public Money(double value, string currency)
        {
            Value = value;
            Currency = currency.ToUpper();
        }

        public static Money operator +(Money money1, Money money2)
        {
            if (money1.Currency.Equals(money2.Currency))
                return new Money(money1.Value + money2.Value, money1.Currency);

            throw new ArithmeticException("Attempt adding values with different Currency type.");
        }

        public static Money operator -(Money money1, Money money2)
        {
            if (money1.Currency.Equals(money2.Currency))
                return new Money(money1.Value - money2.Value, money1.Currency);

            throw new ArithmeticException("Attempt subtract values with different Currency type.");
        }

        public static implicit operator Money(string value)
        {
            return new Money(value);
        }

        public override string ToString()
        {
            return $"{Value} {Currency}";
        }
    }
}
