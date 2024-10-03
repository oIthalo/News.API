using Microsoft.EntityFrameworkCore;
using NoticesAPI.Models;
namespace NoticesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts)
        : base(opts) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}