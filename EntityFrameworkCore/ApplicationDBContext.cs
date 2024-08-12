using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        private static IConfigurationRoot? _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public static string? ConnectionString = _configuration.GetSection("ConnectionString").Value;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Blog>()
                 .HasOne(p => p.BlogImage)
                 .WithOne(p => p.Blog)
                 .HasForeignKey<BlogImage>(p => p.BlogId);
        }

        public DbSet<Blog> Blogs { get; set; }

    }
}
