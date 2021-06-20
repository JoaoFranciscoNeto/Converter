namespace Converter.Core
{
    using System;

    public class UnrecognizedUnitException : Exception
    {
        public UnrecognizedUnitException(string? symbol) : base($"{symbol} is not recognized as a symbol for a unit")
        {
        }
    }
}