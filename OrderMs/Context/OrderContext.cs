using Microsoft.EntityFrameworkCore;
using OrderMs.Models;

namespace OrderMs.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}
