using System;

namespace Lab2
{
    class IndexOutOfRangeException : Exception
    {
        private const string DEFAULT_MESSAGE = "Index Out Of Range";
        public IndexOutOfRangeException(string message) : base(DEFAULT_MESSAGE + ":\n" + message)
        {
        }
    }
}