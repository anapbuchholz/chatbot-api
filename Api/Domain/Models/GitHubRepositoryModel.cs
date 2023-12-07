using System;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public sealed class GitHubRepositoryModel
    {
        public GitHubRepositoryModel(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}