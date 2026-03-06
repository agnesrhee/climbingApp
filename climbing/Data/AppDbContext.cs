using climbing.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace climbing.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}

