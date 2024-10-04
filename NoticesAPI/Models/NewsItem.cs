using NoticesAPI.Data.DTOs;
namespace News.API.Models;

public class NewsItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Topics { get; set; }
    public UserDtoRead Author { get; set; }
    public DateTime PublishedDate { get; set; }
}