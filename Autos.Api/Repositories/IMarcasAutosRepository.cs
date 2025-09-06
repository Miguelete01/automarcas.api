using Autos.Api.Data;
using Autos.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autos.Api.Repositories
{
    public interface IMarcasAutosRepository
    {
        Task<IEnumerable<MarcasAutosEntity>> GetAllAsync();
        Task<MarcasAutosEntity?> GetByIdAsync(int id);
        Task<MarcasAutosEntity> AddAsync(MarcasAutosEntity marcaAutos);
        Task<bool> UpdateAsync(MarcasAutosEntity marcaAutos);
    }
    public class MarcasAutosRepository : IMarcasAutosRepository
    {
        private readonly AutosDbContext _dbContext;

        public MarcasAutosRepository(AutosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MarcasAutosEntity> AddAsync(MarcasAutosEntity marcaAutos)
        {
            try
            {
                marcaAutos.CreatedAt = DateTime.UtcNow;
                marcaAutos.UpdatedAt = DateTime.UtcNow;
                var marcaAuto = (await _dbContext.MarcasAutos.AddAsync(marcaAutos)).Entity;
                await _dbContext.SaveChangesAsync();
                return marcaAuto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<IEnumerable<MarcasAutosEntity>> GetAllAsync()
        {
            return await _dbContext.MarcasAutos.ToListAsync();
        }

        public async Task<MarcasAutosEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.MarcasAutos.FirstOrDefaultAsync(ma => ma.Id == id);
        }

        public async Task<bool> UpdateAsync(MarcasAutosEntity marcaAutos)
        {
            try
            {
                marcaAutos.UpdatedAt = DateTime.UtcNow;
                _dbContext.MarcasAutos.Update(marcaAutos);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
