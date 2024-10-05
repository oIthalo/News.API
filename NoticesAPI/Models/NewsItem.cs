using NewsAPI.Models;
using NoticesAPI.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace News.API.Models;

public class NewsItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonPropertyName("source")]
    public Source Source { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("urlToImage")]
    public string UrlToImage { get; set; }

    [JsonPropertyName("publishedAt")]
    public DateTime PublishedAt { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}