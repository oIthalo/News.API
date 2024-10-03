using NoticesAPI.Models;
namespace NoticesAPI.Data.DTOs;

public class UserDtoRead
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
}