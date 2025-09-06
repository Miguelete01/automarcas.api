using Autos.Api.Entities;
using Autos.Api.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Autos.Api.Data
{
    public class AutosDbContext : DbContext
    {
        public AutosDbContext(DbContextOptions<AutosDbContext> options) : base(options)
        {
        }
        
        public DbSet<MarcasAutosEntity> MarcasAutos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MarcasAutosSeed());
            base.OnModelCreating(modelBuilder);
        }
    }
}
