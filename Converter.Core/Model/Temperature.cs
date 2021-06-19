// <copyright file="Temperature.cs" company="Mercedes-Benz Grand Prix Limited">
// Copyright (c) Mercedes-Benz Grand Prix Limited. All rights reserved.
// </copyright>

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

        public double As(TemperatureUnit targetUnit)
        {
            var baseValue = this.GetBaseValue();

            return targetUnit switch
            {
                TemperatureUnit.Fahrenheit => 9.0 / 5.0 * (baseValue - 273.15) + 32.0,
                TemperatureUnit.Celsius => baseValue - 273.15,
                TemperatureUnit.Kelvin => baseValue,
                _ => throw new NotImplementedException(),
            };
        }

        private double GetBaseValue() => this.unit switch
        {
            TemperatureUnit.Kelvin => this.value,
            TemperatureUnit.Fahrenheit => 5.0 / 9.0 * (this.value - 32.0) + 273.15,
            TemperatureUnit.Celsius => this.value + 273.15,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}