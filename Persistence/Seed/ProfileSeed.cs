using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Seed;

public class ProfileSeed : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasData(
            new Profile() { IdProfile = 1, ProfileName = "Administrador" },
            new Profile() { IdProfile = 2, ProfileName = "Super Usuario" },
            new Profile() { IdProfile = 3, ProfileName = "Usuario" }
        );
    }
}