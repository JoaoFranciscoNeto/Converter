namespace Converter.Core
{
    using System;
    using System.Linq;
    using Converter.Core.Model;

    public static class UnitConverter
    {
        public static bool Convert(double value, string source, string target, out double converted)
        {
            var sourceUnit = GetUnitInfo(source);
            var targetUnit = GetUnitInfo(target);

            if (sourceUnit.Quantity != targetUnit.Quantity)
            {
                throw new ArgumentException($"{source} and {target} do not represent the same quantity.");
            }

            return Convert(value, sourceUnit, targetUnit, out converted);
        }

        public static double ToSi(double value, string source) => GetUnitInfo(source).ToSi(value);

        public static double FromSi(double value, string source) => GetUnitInfo(source).FromSi(value);

        public static UnitInfo GetUnitInfo(string symbol) => UnitList.List.TryGetValue(symbol, out var info)
            ? info
            : throw new UnrecognizedUnitException(nameof(symbol));

        public static UnitInfo[] GetUnitsForQuantity(string quantity)
        {
            return UnitList.List.Values.Where(u => u.Quantity.ToString().Equals(quantity)).ToArray();
        }

        private static bool Convert(double value, UnitInfo source, UnitInfo target, out double converted)
        {
            if (source == target)
            {
                converted = value;
                return true;
            }

            try
            {
                converted = FromSi(ToSi(value, source), target);
                return true;
            }
            catch (UnrecognizedUnitException)
            {
                converted = double.NaN;
                return false;
            }
        }

        private static double ToSi(double value, UnitInfo source) => source.ToSi(value);

        private static double FromSi(double value, UnitInfo source) => source.FromSi(value);
    }
}