using Microsoft.AspNetCore.Mvc;
using News.API.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace News.API.Controllers;

[ApiController]
[Route("v1/news")]
public class NewsController : ControllerBase
{
    private INewsService _newsService;

    public NewsController(INewsService newsService)
        => _newsService = newsService;

    [HttpGet("all-news")]
    public async Task<IActionResult> GetAllNews()
    {
        try
        {
            var news = await _newsService.GetAllNewsAsync();
            if (news is null || !news.Any()) return NotFound();
            return Ok(news);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("{query}")]
    public async Task<IActionResult> GetNewsByQuery(string query)
    {
        try
        {
            var news = await _newsService.GetNewsAsync(query);
            if (news == null || !news.Any()) return NotFound();
            return Ok(news);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("resumed/{query}")]
    public async Task<IActionResult> GetNewsResumed(string query)
    {
        try
        {
            var news = await _newsService.GetNewsResumedAsync(query);
            if (news is null || !news.Any()) return NotFound();
            return Ok(news);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("by{category}")]
    public async Task<IActionResult> GetNewsByCategory(string category)
    {
        try
        {
            var news = await _newsService.GetNewsByCategory(category);
            if (news is null || !news.Any()) return NotFound();
            return Ok(news);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpGet("popular/{limit}")]
    public async Task<IActionResult> GetPopularNews(int limit)
    {
        try
        {
            var news = await _newsService.GetPopularNews(limit);
            if (news is null || !news.Any()) return NotFound();
            return Ok(news);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}