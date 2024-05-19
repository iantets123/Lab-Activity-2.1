using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
	public class StoreDBContext : DbContext
	{
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
