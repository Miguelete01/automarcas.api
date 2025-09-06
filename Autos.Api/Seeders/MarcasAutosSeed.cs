using Autos.Api.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace Autos.Api.Seeders
{
    public class MarcasAutosSeed : IEntityTypeConfiguration<MarcasAutosEntity>
    {
        public void Configure(EntityTypeBuilder<MarcasAutosEntity> builder)
        {
            builder.HasData(new List<MarcasAutosEntity>()
            {
                new MarcasAutosEntity() {
                    Id = 1,
                    Name = "Toyota",
                    Description = "Marca de autos japonesa",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new MarcasAutosEntity() {
                    Id = 2,
                    Name = "Susuki",
                    Description = "Es una empresa multinacional japonesa dedicada a la fabricación de automóviles",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new MarcasAutosEntity() {
                    Id = 3,
                    Name = "Audi",
                    Description = "Audi es una empresa automotriz de origen alemán fundada en 1909",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new MarcasAutosEntity() {
                    Id = 4,
                    Name = "BMW",
                    Description = "BMW fue fundada en 1916 en Múnich, Alemania, inicialmente como fabricante de motores de avión",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                }
            });
        }
    }
}
