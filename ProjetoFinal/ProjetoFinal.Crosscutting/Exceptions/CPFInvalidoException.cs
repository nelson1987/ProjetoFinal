using System;

namespace Ephesto.Crosscutting.Exceptions
{
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException()
            : base()
        {
        }

        public CpfInvalidoException(string message)
            : base(message)
        {
        }

        public CpfInvalidoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
