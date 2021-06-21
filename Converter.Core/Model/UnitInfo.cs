namespace Converter.Core.Model
{
    using System;
    using System.Text.Json.Serialization;

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

        [JsonIgnore] public Func<double, double> FromSi { get; }

        [JsonIgnore] public Func<double, double> ToSi { get; }

        [JsonIgnore] public Quantity Quantity { get; }

        public string QuantityName => Enum.GetName(typeof(Quantity), this.Quantity);

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