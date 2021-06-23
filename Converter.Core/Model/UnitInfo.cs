namespace Converter.Core.Model
{
    using System;
    using System.Diagnostics;
    using System.Text.Json.Serialization;

    [DebuggerDisplay("{"+nameof(Name)+"}")]
    public class UnitInfo
    {
        public UnitInfo(
            Quantity quantity,
            string name,
            string symbol) : this(quantity, name, symbol, d => d, d => d, true)
        {
        }

        public UnitInfo(
            Quantity quantity,
            string name,
            string symbol,
            Func<double, double> fromSi,
            Func<double, double> toSi) : this(quantity, name, symbol, fromSi, toSi, false)
        {
        }

        private UnitInfo(
            Quantity quantity,
            string name,
            string symbol,
            Func<double, double> fromSi,
            Func<double, double> toSi,
            bool isSiBase)
        {
            this.Quantity = quantity;
            this.Name = name;
            this.Symbol = symbol;
            this.FromSi = fromSi;
            this.ToSi = toSi;
            this.IsSiBase = isSiBase;
        }

        [JsonIgnore] public Func<double, double> FromSi { get; }

        [JsonIgnore] public Func<double, double> ToSi { get; }

        [JsonIgnore] public Quantity Quantity { get; }

        public string QuantityName => Enum.GetName(typeof(Quantity), this.Quantity);

        public string Name { get; }

        public string Symbol { get; }

        internal bool IsSiBase { get; }
    }

    public enum Quantity
    {
        Temperature,
        Time,
        Length,
    }
}