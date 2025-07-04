using Actividad2_BD_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_BD_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>().ToTable("Customer", schema: "Sales");
        }
    }
}