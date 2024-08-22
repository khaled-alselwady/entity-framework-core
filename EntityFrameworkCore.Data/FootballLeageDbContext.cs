using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore.Data
{
    public class FootballLeageDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot? _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string? ConnectionString = _configuration.GetSection("ConnectionString").Value;

            optionsBuilder.UseSqlServer(ConnectionString)
            .LogTo(log =>
            {
                // Filter out logs that contain the SQL command text
                if (log.Contains("Executed DbCommand"))
                {
                    var sqlQuery = log.Substring(log.IndexOf("SELECT"));
                    Console.WriteLine(sqlQuery);
                    Console.WriteLine();
                }
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                    new Team
                    {
                        TeamId = 1,
                        Name = "Tivoli Gardens F.C.",
                        CreatedDate = DateTimeOffset.UtcNow.DateTime
                    },
                    new Team
                    {
                        TeamId = 2,
                        Name = "Waterhouse F.C.",
                        CreatedDate = DateTimeOffset.UtcNow.DateTime
                    },
                    new Team
                    {
                        TeamId = 3,
                        Name = "Humble Lions F.C.",
                        CreatedDate = DateTimeOffset.UtcNow.DateTime
                    }

                );
        }
    }
}
