using AutoMapper;
using News.API.Data.DTOs;
using News.API.Models;
namespace News.API.Profiles;

public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<NewsItemResume, NewsItem>().ReverseMap();
    }
}