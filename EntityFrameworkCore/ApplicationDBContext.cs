using EntityFrameworkCore.Configurations;
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
            modelBuilder.Entity<AuditEntry>(); // Include
            // modelBuilder.Ignore<Post>(); // Exclude
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());

            //modelBuilder.Entity<Blog>()
            //    .ToTable("Blogs", b => b.ExcludeFromMigrations());

            //modelBuilder.Entity<Post>()
            //    .ToTable("Posts");

            //modelBuilder.Entity<Post>()
            //    .ToTable("Posts", schema: "blogging");
            //modelBuilder.Entity<Post>()
            //    .ToView("SelectPosts", schema: "blogging");
            // modelBuilder.HasDefaultSchema("blogging");

            //modelBuilder.Entity<Blog>()
            //    .Ignore(p => p.AddedOn); // Exclude Property

            //modelBuilder.Entity<Blog>()
            //    .Property(p => p.Url)
            //    .HasColumnName("BlogUrl");

            //modelBuilder.Entity<Blog>(eb =>
            //{
            //    eb.Property(p => p.Url).HasColumnType("nvarchar(200)");
            //    eb.Property(p => p.Rating).HasColumnType("decimal(5,2)");
            //});

            //modelBuilder.Entity<Blog>()
            //    .Property(p => p.Url)
            //    .HasMaxLength(200);

            //modelBuilder.Entity<Blog>()
            //    .Property(p => p.Url)
            //    .HasComment("The url of the blog");

            //modelBuilder.Entity<Book>()
            //    .HasKey(p => p.BookKey)
            //    .HasName("PK_BookKey");

            //modelBuilder.Entity<Book>()
            //    .HasKey(p => new { p.Name, p.Author });

            modelBuilder.Entity<Blog>()
                .Property(p => p.Rating)
                .HasDefaultValue(2);

            modelBuilder.Entity<Blog>()
                .Property(p => p.AddedOn)
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Author>()
                .Property(p => p.DisplayName)
                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

            modelBuilder.Entity<Category>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
