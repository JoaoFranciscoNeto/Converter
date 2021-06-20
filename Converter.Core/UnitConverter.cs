namespace Converter.Core
{
    using System;
    using Converter.Core.Model;

    public static class UnitConverter
    {
        public static bool Convert(double value, string source, string target, out double converted)
        {
            try
            {
                var valueInSi = ToSi(value, source);

                converted = FromSi(valueInSi, target);
                return true;
            }
            catch (UnrecognizedUnitException)
            {
                converted = double.NaN;
                return false;
            }
        }

        public static double ToSi(double value, string source) => GetUnitInfo(source).ToSi(value);

        public static double FromSi(double value, string source) => GetUnitInfo(source).ToSi(value);

        private static UnitInfo GetUnitInfo(string symbol) => UnitList.List.TryGetValue(symbol, out var info)
            ? info
            : throw new UnrecognizedUnitException();
    }

    public class UnrecognizedUnitException : Exception
    {
    }
}