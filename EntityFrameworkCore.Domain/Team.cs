namespace EntityFrameworkCore.Domain;

public class Team : BaseDomainModel
{
    public string? Name { get; set; }
    public int CoachId { get; set; }
    public int? LeagueId { get; set; }
    public League? League { get; set; }

    public List<Match> HomeMatches { get; set; }
    public List<Match> AwayMatches { get; set; }
}
