namespace EntityFrameworkCore.Domain;


public class Coach : BaseDomainModel
{
    public string Name { get; set; }
    public Team? Team { get; set; }
}
