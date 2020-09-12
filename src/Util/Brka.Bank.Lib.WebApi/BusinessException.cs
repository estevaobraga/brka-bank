using System;
using System.Runtime.Serialization;

namespace Brka.Bank.Lib.WebApi
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string erro) : base(erro)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}