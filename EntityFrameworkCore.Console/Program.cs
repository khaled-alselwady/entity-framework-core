// See https://aka.ms/new-console-template for more information
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using (var db = new FootballLeageDbContext())
        {
            var teams = await db.Teams.ToListAsync();

            foreach (var team in teams)
            {
                Console.WriteLine(team.Name);
            }
        };


    }
}