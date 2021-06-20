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
        public void ThatConvertsFahrenheitToKelvin()
        {
            UnitConverter.Convert(20, "F", "K", out var converted).ShouldBeTrue();
            converted.ShouldBe(266.483, .01);
        }
    }
}