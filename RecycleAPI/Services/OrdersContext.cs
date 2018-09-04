using Microsoft.EntityFrameworkCore;
using RecycleAPI.Models;

namespace RecycleAPI.Services
{
    public class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        public APIContext() { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<APIKey> Keys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>().HasMany( v=> v.Keys ).WithOne( k => k.Vendor );
        }


    }
}
