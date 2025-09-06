using Autos.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Autos.Api.Seeders
{
    public class MigrationService
    {
        public static void InitalizeMigration(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            serviceScope.ServiceProvider.GetService<AutosDbContext>()!.Database.Migrate();
        }
    }
}
