using AutoMapper;
using News.API.Data.DTOs;
using News.API.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace News.API.Services;

public class NewsService : INewsService
{
    private HttpClient _httpClient;
    private IMapper _mapper;
    public string ApiKey = Environment.GetEnvironmentVariable("NEWS_API_KEY")!;

    public NewsService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://newsapi.org/v2/");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "NewsAPI/1.0");
        _mapper = mapper;
    }

    public async Task<List<NewsItem>> GetAllNewsAsync()
    {
        var response = await _httpClient.GetAsync($"top-headlines?country=us&apiKey={ApiKey}");
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var news = JsonSerializer.Deserialize<NewsItemResponse>(responseBody);
            return news?.Items ?? new List<NewsItem>();
        }
        throw new Exception($"Error: {response.StatusCode}, {responseBody}");
    }

    public async Task<List<NewsItem>> GetNewsAsync(string query)
    {
        var response = await _httpClient.GetAsync($"everything?q={query}&apiKey={ApiKey}");
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var news = JsonSerializer.Deserialize<NewsItemResponse>(responseBody);
            return news?.Items ?? new List<NewsItem>();
        }
        throw new Exception($"Error: {response.StatusCode}, {responseBody}");
    }

    public async Task<List<NewsItemResume>> GetNewsResumedAsync(string query)
    {
        var response = await _httpClient.GetAsync($"everything?q={query}&apiKey={ApiKey}");
        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);

        if (response.IsSuccessStatusCode)
        {
            var news = JsonSerializer.Deserialize<NewsItemResponseResume>(responseBody);
            return news?.Items ?? new List<NewsItemResume>();
        }

        throw new Exception($"Erro: {response.StatusCode}, {responseBody}");
    }
}