namespace Converter.Core.Test
{
    using System;
    using Converter.Core.Model;
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

        [TestMethod]
        public void ThatGetsUnitsForQuantity()
        {
            var units = UnitConverter.GetUnitsForQuantity("Temperature");
            units.Length.ShouldBe(3);
        }

        [TestMethod]
        public void ThatCreatesBaseSiUnit()
        {
            var unit = new UnitInfo(0, "TestName", "TestSymbol");
            Assert.IsTrue(unit.IsSiBase);
        }
    }
}