using Microsoft.EntityFrameworkCore;
using TestWebAPI.Domain.Models;
using TestWebAPI.Persistance.EntityTypeconfiguration;

namespace TestWebAPI.Persistance.Implementation
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserTypeConfiguration());
        }
    }
}
