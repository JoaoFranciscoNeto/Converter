namespace Converter.Core.Model
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class UnitList
    {
        public static readonly Dictionary<string, UnitInfo> List = new[]
        {
            new UnitInfo(Quantity.Temperature, "Kelvin", "K", d => d, d => d),
            new UnitInfo(Quantity.Temperature, "Celsius", "°C", d => d-273.15, d => d+273.15),
            new UnitInfo(Quantity.Temperature, "Fahrenheit", "F", d => (d-273.15)*(9.0/5.0)+32, d => (d-32)*5.0/9.0+273.15),

            new UnitInfo(Quantity.Time, "Second", "s", d => d, d => d),
            new UnitInfo(Quantity.Time, "Millisecond", "ms", d => d*1e3, d => d*1e-3),
        }.ToDictionary(u => u.Symbol);
    }
}