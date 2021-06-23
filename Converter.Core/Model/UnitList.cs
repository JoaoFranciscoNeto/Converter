namespace Converter.Core.Model
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class UnitList
    {
        public static readonly Dictionary<string, UnitInfo> List = new[]
        {
            new UnitInfo(Quantity.Temperature, "Kelvin", "K"),
            new UnitInfo(Quantity.Temperature, "Celsius", "°C", d => d-273.15, d => d+273.15),
            new UnitInfo(Quantity.Temperature, "Fahrenheit", "F", d => (d-273.15)*(9.0/5.0)+32, d => (d-32)*5.0/9.0+273.15),

            new UnitInfo(Quantity.Time, "Second", "s"),
            new UnitInfo(Quantity.Time, "Millisecond", "ms", d => d*1e3, d => d*1e-3),
            new UnitInfo(Quantity.Time, "Minute", "min", d => d/60, d => d*60),
            new UnitInfo(Quantity.Time, "Hour", "h", d => d/3600, d => d*3600),

            new UnitInfo(Quantity.Length, "Meter", "m"),
            new UnitInfo(Quantity.Length, "Foot", "ft", d => d*3.281, d => d/3.281),
            new UnitInfo(Quantity.Length, "Mile", "mi", d => d/1609, d => d*1609),
        }.ToDictionary(u => u.Symbol);
    }
}