using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seed;

public class PurchaseOrderStatusLogSeed : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasData(
            new Status
            {
                IdStatus = 1,
                StatusName = "Creada",
                Description = "Orden Importada desde un archivo .csv, sin tener ningún Item escaneado."
            },
            new Status
            {
                IdStatus = 2,
                StatusName = "En Proceso",
                Description = "Orden que ha comenzado con el proceso de escaneo de sus Items."
            },
            new Status
            {
                IdStatus = 3,
                StatusName = "Completada",
                Description = "Orden con todos los Items escaneados correctamente."
            },
            new Status
            {
                IdStatus = 4,
                StatusName = "Incompleta",
                Description = "Orden con algunos Items faltantes, que pudiese ser enviada."
            }
        );
    }
}