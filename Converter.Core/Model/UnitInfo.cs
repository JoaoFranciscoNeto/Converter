namespace Converter.Core.Model
{
    using System;

    public class UnitInfo
    {
        public UnitInfo(
            Quantity quantity,
            string name,
            string symbol,
            Func<double, double> fromSi,
            Func<double, double> toSi)
        {
            this.Quantity = quantity;
            this.Name = name;
            this.Symbol = symbol;
            this.FromSi = fromSi;
            this.ToSi = toSi;
        }

        public Func<double, double> FromSi { get; }

        public Func<double, double> ToSi { get; }

        public Quantity Quantity { get; }

        public string Name { get; }

        public string Symbol { get; }
    }

    public enum Quantity
    {
        Temperature,
        Time,
        Length,
    }
}