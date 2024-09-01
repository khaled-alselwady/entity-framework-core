using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EntityFrameworkCore.Data
{
    public class FootballLeageDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<TeamsAndLeaguesView> TeamsAndLeaguesView { get; set; }

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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<TeamsAndLeaguesView>().HasNoKey().ToView("vw_TeamsAndLeagues");

            modelBuilder.HasDbFunction(typeof(FootballLeageDbContext).GetMethod(nameof(GetEarliestTeamMatch), new[] { typeof(int) })).HasName("fn_GetEarliestMatch");
        }

        public DateTime GetEarliestTeamMatch(int teamId) => throw new NotImplementedException();
    }
}
