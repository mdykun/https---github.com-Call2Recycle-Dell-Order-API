using System;
using System.Runtime.Serialization;

namespace RecycleAPI.Services
{
    [Serializable]
    internal class DuplicateOrderException : Exception
    {
        public DuplicateOrderException()
        {
        }

        public DuplicateOrderException(string message) : base(message)
        {
        }

        public DuplicateOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}