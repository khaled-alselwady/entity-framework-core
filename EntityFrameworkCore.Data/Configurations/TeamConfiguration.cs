using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                     new Team
                     {
                         Id = 1,
                         Name = "Tivoli Gardens F.C.",
                         CreatedDate = DateTimeOffset.UtcNow.DateTime
                     },
                     new Team
                     {
                         Id = 2,
                         Name = "Waterhouse F.C.",
                         CreatedDate = DateTimeOffset.UtcNow.DateTime
                     },
                     new Team
                     {
                         Id = 3,
                         Name = "Humble Lions F.C.",
                         CreatedDate = DateTimeOffset.UtcNow.DateTime
                     }

                 );
        }
    }
}
