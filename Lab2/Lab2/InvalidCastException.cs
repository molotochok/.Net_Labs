using System;

namespace Lab2
{
    class InvalidCastException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid Cast";
        public InvalidCastException(string message) : base(DEFAULT_MESSAGE + ":\n" + message)
        {
        }
    }
}
