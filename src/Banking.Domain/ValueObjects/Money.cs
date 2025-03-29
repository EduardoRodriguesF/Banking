using System;
using System.Numerics;

namespace Banking.Domain
{
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money(decimal amount, string currency)
        {
            Amount = Math.Round(amount, 2, MidpointRounding.AwayFromZero);
            Currency = currency.ToUpper();
        }

        public static Money Create(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount must be greater than or equal to zero.", nameof(amount));

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency must not be null or empty.", nameof(currency));

            return new Money(amount, currency);
        }

        public Money Add(Money other)
        {
            if (other.Currency != Currency)
                throw new InvalidOperationException("Cannot add other with different currencies.");
            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            if (other.Currency != Currency)
                throw new InvalidOperationException("Cannot add other with different currencies.");
            return new Money(Amount - other.Amount, Currency);
        }

        public bool Equals(Money? other)
        {
            if (other is null)
            {
                return false;
            }

            return this.Currency == other.Currency && this.Amount == other.Amount;
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }

        public static bool operator >(Money left, Money right)
        {
            return left.Amount > right.Amount;
        }

        public static bool operator <(Money left, Money right)
        {
            return left.Amount < right.Amount;
        }
    }
}
