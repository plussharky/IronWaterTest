using IronWaterStudioNet6.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IronWaterStudioNet6.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(ProductDbContext context)
        {
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "iPhone 12 (PRODUCT)RED",
                    Description = "Apple IPhone 12, 256 Gb ",
                    Price = 74990m
                },
                new Product
                {
                    Name = "iPhone 12 White",
                    Description = "Apple IPhone 12, 128 Gb",
                    Price = 62990m
                },
                new Product
                {
                    Name = "iPhone 13 mini Blue",
                    Description = "Apple IPhone 13 mini, 256 Gb",
                    Price = 79990m
                },
                new Product
                {
                    Name = "iPhone 13 Pro Green",
                    Description = "Apple IPhone 13 Pro, 512 Gb",
                    Price = 118990m
                },
                new Product
                {
                    Name = "iPhone 14 Pro Black",
                    Description = "Apple IPhone 14 Pro, 128 Gb",
                    Price = 114990m
                }
                );
                context.SaveChanges();
            }
        }
    }
}
