using System.Text.Json.Serialization;
namespace News.API.Models;

public class Source
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
