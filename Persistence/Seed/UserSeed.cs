using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Seed;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                IdUser = 1,
                FirstName = "Administrador",
                LastName = "Sistema",
                Email = "admin@example.com",
                UserName = "admin",
                HashPassword = "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97",
                IdProfile = 1
            },
            new User
            {
                IdUser = 2,
                FirstName = "Gerardo",
                LastName = "Martinez Briones",
                Email = "gerardo.martinez@drivespro.com",
                UserName = "gerardo.martinez",
                HashPassword = "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97",
                IdProfile = 1
            },
            new User
            {
                IdUser = 3,
                FirstName = "Victor",
                LastName = "Luna Narvaez",
                Email = "victor.luna@drivespro.com",
                UserName = "victor.luna",
                HashPassword = "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97",
                IdProfile = 1
            },
            new User
            {
                IdUser = 4,
                FirstName = "Israel",
                LastName = "Salas",
                Email = "israel.salas@drivespro.com",
                UserName = "israel.salas",
                HashPassword = "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97",
                IdProfile = 1
            });
    }
}