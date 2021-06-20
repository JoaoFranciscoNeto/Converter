namespace Converter.Core
{
    using System;
    using Converter.Core.Model;

    public static class UnitConverter
    {
        public static bool Convert(double value, string source, string target, out double converted)
        {
            var sourceUnit = GetUnitInfo(source);
            var targetUnit = GetUnitInfo(target);

            if (sourceUnit.Quantity != targetUnit.Quantity)
            {
                throw new ArgumentException($"{nameof(source)} and {nameof(targetUnit)} do not represent same quantities");
            }

            return Convert(value, sourceUnit, targetUnit, out converted);
        }

        public static double ToSi(double value, string source) => GetUnitInfo(source).ToSi(value);

        public static double FromSi(double value, string source) => GetUnitInfo(source).FromSi(value);

        public static UnitInfo GetUnitInfo(string symbol) => UnitList.List.TryGetValue(symbol, out var info)
            ? info
            : throw new UnrecognizedUnitException(nameof(symbol));

        private static bool Convert(double value, UnitInfo source, UnitInfo target, out double converted)
        {
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