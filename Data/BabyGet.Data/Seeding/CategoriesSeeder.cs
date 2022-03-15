using BabyGet.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BabyGet.Data.Seeding
{
    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Car Seats" });
            await dbContext.Categories.AddAsync(new Category { Name = "Strollers" });
            await dbContext.Categories.AddAsync(new Category { Name = "Eat" });
            await dbContext.Categories.AddAsync(new Category { Name = "Play" });
            await dbContext.Categories.AddAsync(new Category { Name = "Swings" });
            await dbContext.Categories.AddAsync(new Category { Name = "Bath" });
            await dbContext.Categories.AddAsync(new Category { Name = "Safety" });
            await dbContext.Categories.AddAsync(new Category { Name = "Outdoors" });

            await dbContext.SaveChangesAsync();
        }
    }
}
