using System;

namespace Lab2
{
    class ArrayTypeMismatchException : Exception
    {
        private const string DEFAULT_MESSAGE = "Array Type Mismatch";
        public ArrayTypeMismatchException(string message) : base(DEFAULT_MESSAGE + ":\n" + message)
        {
        }
    }
}