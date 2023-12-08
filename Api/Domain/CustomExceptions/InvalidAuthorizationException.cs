using System.Net;

namespace Domain.CustomExceptions
{
    public sealed class InvalidAuthorizationException : CustomExceptionBase
    {
        public InvalidAuthorizationException(string communicatingTo) : base($"invalid token to {communicatingTo}", HttpStatusCode.Unauthorized)
        {
        }
    }
}
