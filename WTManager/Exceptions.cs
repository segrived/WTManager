using System;
using System.Runtime.Serialization;

namespace WTManager
{
    [Serializable]
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException() {
        }

        public ServiceNotFoundException(string message) : base(message) {
        }

        public ServiceNotFoundException(string message, Exception inner) : base(message, inner) {
        }

        protected ServiceNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) {
        }
    }
}