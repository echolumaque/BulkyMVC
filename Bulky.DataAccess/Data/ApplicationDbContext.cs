using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Category { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var categories = new List<Category>
        {
            new() { Id = 1,  Name = "Action", DisplayOrder = 1 },
            new() { Id = 2,  Name = "SciFi", DisplayOrder = 2 },
            new() { Id = 3,  Name = "History", DisplayOrder = 3 },
        };

        modelBuilder.Entity<Category>()
            .HasData(categories);
    }
}
