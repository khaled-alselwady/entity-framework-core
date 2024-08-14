using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        private static IConfigurationRoot? _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private static string? ConnectionString = _configuration.GetSection("ConnectionString").Value;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Posts)
                .UsingEntity<PostTag>(
                    j => j
                         .HasOne(pt => pt.Tags)
                         .WithMany(t => t.PostTags)
                         .HasForeignKey(pt => pt.TagId),
                    j => j
                         .HasOne(pt => pt.Posts)
                         .WithMany(p => p.PostTags)
                         .HasForeignKey(pt => pt.PostId),
                    j =>
                    {
                        j.Property(pt => pt.CreateAt).HasDefaultValue("GetDate()");
                        j.HasKey(t => t.PostTagId);
                    }
                );
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
    }
}
