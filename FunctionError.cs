using System;
using System.Runtime.Serialization;

namespace Graph
{
    [Serializable]
    internal class FunctionError : Exception
    {
        public FunctionError()
        {
        }

        public FunctionError(string message) : base(message)
        {
        }

        public FunctionError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FunctionError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}