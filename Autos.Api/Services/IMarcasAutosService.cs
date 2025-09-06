using Autos.Api.Dtos;
using Autos.Api.Entities;
using Autos.Api.Repositories;

namespace Autos.Api.Services
{
    public interface IMarcasAutosService
    {
        /// <summary>
        /// Obtiene todas las marcas de autos.
        /// </summary>
        /// <returns>Lista de las marcas existentes</returns>
        Task<BaseResponse<IEnumerable<MarcaAutoDto>>> GetAllAsync();
        /// <summary>
        /// obtiene una marca de auto por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La marca y una descripcion</returns>
        Task<BaseResponse<MarcaAutoDto>> GetByIdAsync(int id);
        /// <summary>
        /// Agrega una nueva marca de auto.
        /// </summary>
        /// <param name="marcaAutos"></param>
        /// <returns>Mensaje de completado | error</returns>
        Task<BaseResponse<string>> AddAsync(MarcaAutoDto marcaAutos);
        /// <summary>
        /// Actualiza una marca de auto existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="marcaAutos"></param>
        /// <returns>Mensaje de completado o si no se pudo completar</returns>
        Task<BaseResponse<string>> UpdateAsync(int id, MarcaAutoDto marcaAutos);
    }

    public class MarcasAutosService : IMarcasAutosService
    {
        private readonly IMarcasAutosRepository _marcasAutosRepository;
        public MarcasAutosService(IMarcasAutosRepository marcasAutosRepository)
        {
            _marcasAutosRepository = marcasAutosRepository;
        }

        public async Task<BaseResponse<string>> AddAsync(MarcaAutoDto marcaAutos)
        {
            try
            {
                var newMarcaAuto = new MarcasAutosEntity
                {
                    Name = marcaAutos.Name,
                    Description = marcaAutos.Description,
                    IsActive = marcaAutos.IsActive,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _ = await _marcasAutosRepository.AddAsync(newMarcaAuto);
                return BaseResponse<string>
                    .CreateSuccessResponse("Marca de auto agregada con éxito", "Marca de auto agregada con éxito", 201);
            }
            catch (Exception ex)
            {
                return BaseResponse<string>
                    .CreateErrorResponse($"Error al crear la marca auto: {ex.Message}", 500);
            }
        }

        public async Task<BaseResponse<IEnumerable<MarcaAutoDto>>> GetAllAsync()
        {
            try
            {
                var marcasAutos = await _marcasAutosRepository.GetAllAsync();

                if (!marcasAutos.Any())
                {
                    return BaseResponse<IEnumerable<MarcaAutoDto>>
                        .CreateSuccessResponse(new List<MarcaAutoDto>(), "No se encontraron marcas de autos", 200);
                }

                return BaseResponse<IEnumerable<MarcaAutoDto>>
                    .CreateSuccessResponse([.. marcasAutos.Select(ma => new MarcaAutoDto
                    {
                        Name = ma.Name,
                        Description = ma.Description,
                        IsActive = ma.IsActive
                    })], "Marcas de autos obtenidas con éxito", 200);
            }
            catch (Exception ex)
            {
                return BaseResponse<IEnumerable<MarcaAutoDto>>
                    .CreateErrorResponse($"Error al obtener las marcas de autos: {ex.Message}", 500);
            }
            
        }

        public async Task<BaseResponse<MarcaAutoDto>> GetByIdAsync(int id)
        {
            try
            {
                var marcaAuto = await _marcasAutosRepository.GetByIdAsync(id);

                if (marcaAuto is null)
                {
                    return BaseResponse<MarcaAutoDto>
                        .CreateErrorResponse("Marca de auto no encontrada", 404);
                }

                return BaseResponse<MarcaAutoDto>
                    .CreateSuccessResponse(new MarcaAutoDto
                    {
                        Name = marcaAuto.Name,
                        Description = marcaAuto.Description,
                        IsActive = marcaAuto.IsActive
                    }, "Marca de auto obtenida con éxito", 200);
            }
            catch (Exception ex)
            {
                return BaseResponse<MarcaAutoDto>
                    .CreateErrorResponse($"Error al obtener la marcas de auto: {ex.Message}", 500);
            }
        }

        public async Task<BaseResponse<string>> UpdateAsync(int id, MarcaAutoDto marcaAutos)
        {
            try
            {
                var existingMarcaAuto = await _marcasAutosRepository.GetByIdAsync(id);
                if (existingMarcaAuto is null)
                {
                    return BaseResponse<string>
                        .CreateErrorResponse("Marca de auto no encontrada", 404);
                }

                existingMarcaAuto.Name = marcaAutos.Name;
                existingMarcaAuto.Description = marcaAutos.Description;
                existingMarcaAuto.IsActive = marcaAutos.IsActive;
                existingMarcaAuto.UpdatedAt = DateTime.Now;

                var updateMarcaAuto = await _marcasAutosRepository.UpdateAsync(existingMarcaAuto);

                if (!updateMarcaAuto)
                    return BaseResponse<string>
                        .CreateSuccessResponse("No se realizaron cambios", "No se realizaron cambios", 200);

                return BaseResponse<string>
                    .CreateSuccessResponse("Marca de auto actualizada con éxito", "Marca de auto actualizada con éxito", 200);

            }
            catch (Exception ex)
            {
                return BaseResponse<string>
                    .CreateErrorResponse($"Error al actualizar la marcas de auto: {ex.Message}", 500);
            }
        }
    }
}
