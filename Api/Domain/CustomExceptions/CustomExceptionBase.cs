using System;
using System.Net;

namespace Domain.CustomExceptions
{
    public abstract class CustomExceptionBase : Exception
    {
        public CustomExceptionBase(string message, HttpStatusCode status) : base(message)
        {
            Status = status;
        }

        public HttpStatusCode Status { get; private set; }
    }
}
