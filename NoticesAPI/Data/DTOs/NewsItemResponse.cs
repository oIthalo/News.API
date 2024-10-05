using News.API.Models;
using System.Text.Json.Serialization;
namespace News.API.Data.DTOs;

public class NewsItemResponse
{
    [JsonPropertyName("articles")]
    public List<NewsItem> Items { get; set; }
}