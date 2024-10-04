using NewsAPI.Constants;
namespace News.API.Models;

public class UserPreferences
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<string> Topics { get; set; }
    public string PreferredKeyword { get; set; }
    public Languages PreferredLanguage { get; set; }
    public SortBys PreferredSortBy { get; set; }
    public DateTime FromDate { get; set; }
}