using Microsoft.EntityFrameworkCore;

namespace RepertoriumAPI.Entities;

public class RepertoriumDbContext : DbContext
{
    public RepertoriumDbContext(DbContextOptions<RepertoriumDbContext> options) : base(options) { }

    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>()
            .Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(40);
        modelBuilder.Entity<Advertisement>()
            .Property(a => a.Description)
            .IsRequired();


        modelBuilder.Entity<Category>()
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(40);
    }
}