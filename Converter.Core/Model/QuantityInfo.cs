namespace Converter.Core.Model
{
    using System;

    public class Temperature
    {
        private readonly double value;
        private readonly TemperatureUnit unit;

        public Temperature(double value, TemperatureUnit unit)
        {
            this.value = value;
            this.unit = unit;
        }

        public double As(TemperatureUnit unit)
        {
            var baseValue = this.GetBaseValue();

            return this.unit switch
            {
                TemperatureUnit.Fahrenheit => 9.0 / 5.0 * (baseValue - 273) + 32,
                TemperatureUnit.Celsius => baseValue - 273,
                TemperatureUnit.Kelvin => baseValue,
                _ => throw new NotImplementedException(),
            };
        }

        private double GetBaseValue() => this.unit switch
        {
            TemperatureUnit.Kelvin => this.value,
            TemperatureUnit.Fahrenheit => 5.0 / 9.0 * (this.value - 32.0) + 273.0,
            TemperatureUnit.Celsius => this.value + 273,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public enum TemperatureUnit
    {
        Fahrenheit,
        Celsius,
        Kelvin,
    }
}