namespace Converter.Core.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class TemperatureTests
    {
        // TODO: Use DataTestMethods

        [TestMethod]
        public void ThatConvertsCelsiusToKelvin()
        {
            UnitConverter.Convert(20, "°C", "K", out var converted).ShouldBeTrue();
            converted.ShouldBe(293.15, .01);
        }

        [TestMethod]
        public void ThatConvertsKelvinToCelsius()
        {
            UnitConverter.Convert(20, "K", "°C", out var converted).ShouldBeTrue();
            converted.ShouldBe(-253.15, .01);
        }

        [TestMethod]
        public void ThatConvertsFahrenheitToKelvin()
        {
            UnitConverter.Convert(20, "F", "K", out var converted).ShouldBeTrue();
            converted.ShouldBe(266.483, .01);
        }

        [TestMethod]
        public void ThatConvertsKelvinToFahrenheit()
        {
            UnitConverter.Convert(20, "K", "F", out var converted).ShouldBeTrue();
            converted.ShouldBe(-423.67, .01);
        }

        [TestMethod]
        public void ThatConvertsCelsiusToFahrenheit()
        {
            UnitConverter.Convert(20, "°C", "F", out var converted).ShouldBeTrue();
            converted.ShouldBe(68.0, .01);
        }

        [TestMethod]
        public void ThatConvertsFahrenheitToCelsius()
        {
            UnitConverter.Convert(20, "F", "°C", out var converted).ShouldBeTrue();
            converted.ShouldBe(-6.66667, .01);
        }
    }
}