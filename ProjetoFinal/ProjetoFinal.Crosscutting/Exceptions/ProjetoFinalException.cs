using System;

namespace ProjetoFinal.Crosscutting.Exceptions
{
    public interface IProjetoFinalException
    {
    }

    [Serializable]
    public class ProjetoFinalException : Exception, IProjetoFinalException
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