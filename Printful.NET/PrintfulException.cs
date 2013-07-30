using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Printful.NET
{
    public class PrintfulException : Exception
    {
        public PrintfulException() : base() { }

        public PrintfulException(string message) : base(message) { }

        public PrintfulException(string message, Exception innerException) : base(message, innerException) {}

        public PrintfulException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
