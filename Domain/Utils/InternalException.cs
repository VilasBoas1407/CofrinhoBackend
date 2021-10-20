using System;

namespace Domain.Utils
{
    public class InternalException : Exception
    {
        public int HttpStatusCode { get; set; }
        public string MessageError { get; set; }

        public InternalException(int HttpStatusCode, string MessageError)
        {
            this.HttpStatusCode = HttpStatusCode;
            this.MessageError = MessageError;
        }

        public InternalException(string MessageError)
        {
            this.MessageError = MessageError;
            this.HttpStatusCode = 500;
        }
    }
}
