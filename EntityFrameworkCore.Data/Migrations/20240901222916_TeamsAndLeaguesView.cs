using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeamsAndLeaguesView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create view vw_TeamsAndLeagues
                as 
                select t.Name as TeamName , l.Name as LeagueName
                from Teams t
                left join Leagues l
                on t.LeagueId = l.Id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view vw_TeamsAndLeagues");
        }
    }
}
