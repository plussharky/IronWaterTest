using Microsoft.EntityFrameworkCore;

namespace IronWaterStudioNet6.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) 
        { 

        }

        public DbSet<Product> Products { get; set; }
    }
}
