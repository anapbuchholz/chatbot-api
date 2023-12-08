using Domain.CustomExceptions;
using System.Net;

namespace Infrastructure
{
    internal static class InfrastructureFailuresValidator
    {
        public static void Validate(HttpStatusCode status, string serviceName)
        {
            switch (status)
            {
                case HttpStatusCode.Unauthorized: throw new InvalidAuthorizationException(serviceName);
                case HttpStatusCode.Forbidden: throw new InvalidAuthorizationException(serviceName);
                case HttpStatusCode.InternalServerError: throw new ThirdPartySeviceFailureException(serviceName);
                case HttpStatusCode.BadGateway: throw new ThirdPartySeviceFailureException(serviceName);
                case HttpStatusCode.GatewayTimeout: throw new ThirdPartySeviceFailureException(serviceName);
                default: throw new Exception();
            }
        }
    }
}
