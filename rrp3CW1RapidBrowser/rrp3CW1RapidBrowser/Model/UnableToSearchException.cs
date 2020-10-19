using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;

namespace rrp3CW1RapidBrowser
{
    [Serializable]
    class UnableToSearchException : Exception
    {

        RapidBrowser RB = new RapidBrowser();
        private const string DefaultMessage = "Unable to search and retrive user requested URL";

        public UnableToSearchException()
        : base(DefaultMessage)
        {
        }

        public UnableToSearchException(string message)
        : base(message)
        {
        }

        public UnableToSearchException(string message, Exception innerException)
        : base(message, innerException)
        {
        }

        
        protected UnableToSearchException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}