using System;

namespace Lab2
{
    class OverflowException : Exception
    {
        private const string DEFAULT_MESSAGE = "Overflow";
        public OverflowException(string message) : base(DEFAULT_MESSAGE + ":\n" + message)
        {
        }
    }
}
