using IVQ.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IVQ.WebApi.Data;

public class IVQDbContext : DbContext
{
    public IVQDbContext(DbContextOptions<IVQDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Question> Questions { get; set; }
}