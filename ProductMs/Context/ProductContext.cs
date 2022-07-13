using Microsoft.EntityFrameworkCore;
using ProductMs.Models;

namespace ProductMs.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
