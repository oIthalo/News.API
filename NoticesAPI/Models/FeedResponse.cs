using Microsoft.Extensions.Hosting;
namespace News.API.Models;

public class FeedResponse
{
    public List<NewsItem> News { get; set; }
    public List<string> Topics { get; set; }
}