using System.Net;

namespace Domain.CustomExceptions
{
    public sealed class ThirdPartySeviceFailureException : CustomExceptionBase
    {
        public ThirdPartySeviceFailureException(string communicatingTo) : base($"{communicatingTo} failed or is not responding", HttpStatusCode.FailedDependency)
        {
        }
    }
}
