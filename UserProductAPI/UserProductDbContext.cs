using Microsoft.EntityFrameworkCore;
using UserProductAPI.Models;

namespace UserProductAPI
{
    public class UserProductDbContext : DbContext
    {
        public UserProductDbContext(DbContextOptions<UserProductDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>().HasKey(p => p.UserProductID);  // تحديد المفتاح الأساسي لجدول Purchase

            base.OnModelCreating(modelBuilder);
        }
    }
}
