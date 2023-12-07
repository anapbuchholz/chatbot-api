using System.Collections.Generic;

namespace Domain.Ioc.Infrastructure.Http
{
    public sealed class GitHubHttpConfiguration
    {
        public string BaseUrl { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
