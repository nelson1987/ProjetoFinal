using System;

namespace ProjetoFinal.Crosscutting.Exceptions
{
    [Serializable]
    public class ProjetoFinalException : Exception
    {
        public ProjetoFinalException()
            : base()
        {
        }

        public ProjetoFinalException(string message) 
            : base(message)
        {
        }

        public ProjetoFinalException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}