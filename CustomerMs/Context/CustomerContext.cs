using CustomerMs.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerMs.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options) 
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
