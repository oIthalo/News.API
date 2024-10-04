using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
namespace News.API.Services;

public static class NewsApiService
{
    public static void NewsApiClient()
    {
        var apiKey = Environment.GetEnvironmentVariable("NEWS_API_KEY");
        var newsApiClient = new NewsApiClient(apiKey);
        var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
        {
            Q = "Apple",
            SortBy = SortBys.Popularity,
            Language = Languages.PT,
            From = new DateTime(2024, 1, 01)
        });
}