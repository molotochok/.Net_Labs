using System;

namespace Lab2
{
    class StackOverflowException : Exception
    {
        private const string DEFAULT_MESSAGE = "Stack Overflow";
        public StackOverflowException(string message) : base(DEFAULT_MESSAGE + ":\n" + message)
        {
        }
    }
}
