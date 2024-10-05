using System.Text.Json.Serialization;
namespace News.API.Data.DTOs;

public class NewsItemResume
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}
