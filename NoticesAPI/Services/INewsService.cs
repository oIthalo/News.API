using News.API.Data.DTOs;
using News.API.Models;
namespace News.API.Services;

public interface INewsService
{
    Task<List<NewsItem>> GetAllNewsAsync();
    Task<List<NewsItem>> GetNewsAsync(string query);
    Task<List<NewsItemResume>> GetNewsResumedAsync(string query);
    Task<List<NewsItem>> GetNewsByCategory(string category);
    Task<List<NewsItem>> GetPopularNews(int limit);
}