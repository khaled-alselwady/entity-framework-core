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
                    // Handle INSERT commands with sensitive data
                    if (log.Contains("INSERT"))
                    {
                        var insertSql = log.Substring(log.IndexOf("INSERT"));
                        Console.WriteLine(insertSql);
                        Console.WriteLine();
                    }
                    // Handle UPDATE commands with sensitive data
                    else if (log.Contains("UPDATE"))
                    {
                        var updateSql = log.Substring(log.IndexOf("UPDATE"));
                        Console.WriteLine(updateSql);
                        Console.WriteLine();
                    }
                    // Handle DELETE commands with sensitive data
                    else if (log.Contains("DELETE"))
                    {
                        var deleteSql = log.Substring(log.IndexOf("DELETE"));
                        Console.WriteLine(deleteSql);
                        Console.WriteLine();
                    }
                    // Handle SELECT commands without sensitive data
                    else if (log.Contains("SELECT"))
                    {
                        var selectSql = log.Substring(log.IndexOf("SELECT"));
                        Console.WriteLine(selectSql);
                        Console.WriteLine();
                    }

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
