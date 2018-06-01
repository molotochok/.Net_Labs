using System;

namespace Lab2
{
    class OutOfMemoryException : Exception
    {
        private const string DEFAULT_MESSAGE = "Out Of Memory";
        public OutOfMemoryException(string message) : base(DEFAULT_MESSAGE + ":\n" + message)
        {
        }
    }
}
