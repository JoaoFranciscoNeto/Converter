namespace Converter.Core.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void ThatCanConvertSecondsToMilliseconds()
        {
            UnitConverter.Convert(1, "s", "ms", out var converted).ShouldBeTrue();
            converted.ShouldBe(1000, 0.01);
        }

        [TestMethod]
        public void ThatCanConvertMillisecondsToSeconds()
        {
            UnitConverter.Convert(1, "ms", "s", out var converted).ShouldBeTrue();
            converted.ShouldBe(.001, 0.001);
        }
    }
}