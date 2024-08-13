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
            //modelBuilder.Entity<Blog>()
            //    .HasMany(p => p.Posts)
            //    .WithOne()
            //    .HasForeignKey(p => p.BlogId);

            //modelBuilder.Entity<Post>()
            //    .HasOne(p => p.Blog)
            //    .WithMany(p => p.Posts);

            modelBuilder.Entity<Post>()
                .HasOne<Blog>()
                .WithMany()
                .HasForeignKey(p => p.BlogId);
        }

        public DbSet<Blog> Blogs { get; set; }

    }
}
