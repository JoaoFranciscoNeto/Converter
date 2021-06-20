namespace Converter.Core.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class UnitConverterTests
    {
        [TestMethod]
        public void ThatCannotConvertIncompatible()
        {
            Should.Throw<ArgumentException>(() => UnitConverter.Convert(1, "s", "K", out var converted))
                .Message.ShouldBe("s and K do not represent the same quantity.");
        }
    }
}