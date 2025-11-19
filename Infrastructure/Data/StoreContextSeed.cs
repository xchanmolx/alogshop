using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        // Seed data logic goes here (Products)
        if (!context.Products.Any())
        {
            // Add seed data to context.Products
            var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (products == null) return;

            context.Products.AddRange(products);

            await context.SaveChangesAsync();
        }

        // Seed data logic goes here (DeliveryMethods)
        if (!context.DeliveryMethods.Any())
        {
            // Add seed data to context.DeliveryMethods
            var dmData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/delivery.json");

            var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

            if (methods == null) return;

            context.DeliveryMethods.AddRange(methods);

            await context.SaveChangesAsync();
        }
    }
}
