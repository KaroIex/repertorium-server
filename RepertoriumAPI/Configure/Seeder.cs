using Microsoft.EntityFrameworkCore;
using RepertoriumAPI.Entities;

namespace RepertoriumAPI.Configure;

public class Seeder
{
    private readonly RepertoriumDbContext _dbContext;

    public Seeder(RepertoriumDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            var pendingMigrations = _dbContext.Database.GetPendingMigrations();

            if (pendingMigrations != null && !pendingMigrations.Any()) _dbContext.Database.Migrate();

            if (!_dbContext.Categories.Any())
            {
                var categories = GetCategories();
                _dbContext.Categories.AddRange(categories);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Advertisements.Any())
            {
                var advertisements = GetAdvertisements();
                _dbContext.Advertisements.AddRange(advertisements);
                _dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Advertisement> GetAdvertisements()
    {
        return new List<Advertisement>
        {
            new()
            {
                Title = "Sprzedam opla",
                Description = "Prawie jak nowy",
                IsNegotiable = false,
                Category = _dbContext
                    .Categories
                    .FirstOrDefault(c => c.Name == "Motoryzacja"),
                Images = new List<Image>
                {
                    new()
                    {
                        FileName = "jakispng.png"
                    }
                }
            }
        };
    }

    private IEnumerable<Category> GetCategories()
    {
        return new List<Category>
        {
            new()
            {
                Name = "Motoryzacja"
            },
            new()
            {
                Name = "Elektronika"
            },
            new()
            {
                Name = "Zwierzęta"
            }
        };
    }
}