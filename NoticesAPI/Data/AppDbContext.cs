using Microsoft.EntityFrameworkCore;
namespace NoticesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts)
        : base(opts) { }
}