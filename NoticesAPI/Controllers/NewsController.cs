using Microsoft.AspNetCore.Mvc;
using News.API.Services;
namespace News.API.Controllers;

[ApiController]
[Route("v1/news")]
public class NewsController : ControllerBase
{
    private INewsService _newsService;

    public NewsController(INewsService newsService)
        =>   _newsService = newsService;

    [HttpGet("all-news")]
    public async Task<IActionResult> GetAllNews()
    {
        try
        {
            var news = await _newsService.GetAllNewsAsync();
            if (news is null || !news.Any())
                return NoContent();

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
            if (news == null || !news.Any())
                return NoContent();

            return Ok(news);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}