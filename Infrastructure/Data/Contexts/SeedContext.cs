using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data.Contexts
{
    public class SeedContext
    {
        public static async Task SeedAsync (StoreContext context)
        {
            if (!context.Categories.Any())
            {
                var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
                var categories = JsonSerializer.Deserialize<List<Categories>>(categoriesData);
                context.Categories.AddRange(categories);
            }

            if(!context.Users.Any())
            {
                var userData = File.ReadAllText("../Infrastructure/Data/SeedData/user.json");
                var user = JsonSerializer.Deserialize<List<User>>(userData);
                context.Users.AddRange(user);
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }


    }
}
