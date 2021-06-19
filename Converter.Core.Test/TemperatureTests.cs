namespace Converter.Core.Test
{
    using Converter.Core.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class TemperatureTests
    {
        // TODO: Use DataTestMethods

        [TestMethod]
        public void ThatConvertsCelsiusToFahrenheit()
        {
            var celsius = new Temperature(
                20,
                TemperatureUnit.Celsius);

            celsius.As(TemperatureUnit.Fahrenheit).ShouldBe(68);
        }

        [TestMethod]
        public void ThatConvertsKelvinToFahrenheit()
        {
            var kelvin = new Temperature(
                20,
                TemperatureUnit.Kelvin);

            kelvin.As(TemperatureUnit.Fahrenheit).ShouldBe(
                -423.67,
                0.01);
        }

        [TestMethod]
        public void ThatConvertsFahrenheitToCelsius()
        {
            var fahrenheit = new Temperature(
                20,
                TemperatureUnit.Fahrenheit);

            fahrenheit.As(TemperatureUnit.Celsius).ShouldBe(
                -6.67,
                0.01);
        }

        [TestMethod]
        public void ThatConvertsCelsiusToKelvin()
        {
            var celsius = new Temperature(
                20,
                TemperatureUnit.Celsius);

            celsius.As(TemperatureUnit.Kelvin).ShouldBe(
                293.15,
                0.01);
        }

        [TestMethod]
        public void ThatConvertsKelvinToCelsius()
        {
            var kelvin = new Temperature(
                20,
                TemperatureUnit.Kelvin);

            kelvin.As(TemperatureUnit.Celsius).ShouldBe(
                -253.15,
                0.01);
        }

        [TestMethod]
        public void ThatConvertsFahrenheitToKelvin()
        {
            var fahrenheit = new Temperature(
                20,
                TemperatureUnit.Fahrenheit);

            fahrenheit.As(TemperatureUnit.Kelvin).ShouldBe(
                266.483,
                0.01);
        }
    }
}