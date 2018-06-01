using System;

namespace Lab2
{
    class DivideByZeroException : Exception
    {
        private const string DEFAULT_MESSAGE = "Divide By Zero";
        public DivideByZeroException(string message) : base(DEFAULT_MESSAGE + ":\n" + message)
        {
        }
    }
}