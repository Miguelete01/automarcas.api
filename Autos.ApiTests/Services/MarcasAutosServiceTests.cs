using Autos.Api.Dtos;
using Autos.Api.Entities;
using Autos.Api.Repositories;
using Moq;
using Xunit;

namespace Autos.Api.Services.Tests
{
    public class MarcasAutosServiceTests
    {
        private readonly Mock<IMarcasAutosRepository> _mockRepo;
        private readonly MarcasAutosService _service;

        public MarcasAutosServiceTests()
        {
            _mockRepo = new Mock<IMarcasAutosRepository>();
            _service = new MarcasAutosService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsEmptyList_WhenNoData()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<MarcasAutosEntity>());

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Response);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("No se encontraron marcas de autos", result.Message);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsData_WhenDataExists()
        {
            // Arrange
            var marcaAutos = new List<MarcasAutosEntity>
        {
            new MarcasAutosEntity { Name = "Toyota", Description = "Auto", IsActive = true },
            new MarcasAutosEntity { Name = "Honda", Description = "Auto", IsActive = true }
        };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(marcaAutos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Response.Count());
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Marcas de autos obtenidas con éxito", result.Message);
        }

        [Fact]
        public async Task AddAsync_ReturnsSuccess_WhenMarcaIsAdded()
        {
            // Arrange
            var dto = new MarcaAutoDto { Name = "Mazda", Description = "Auto", IsActive = true };
            _mockRepo.Setup(r => r.AddAsync(It.IsAny<MarcasAutosEntity>()))
                     .ReturnsAsync(new MarcasAutosEntity());

            // Act
            var result = await _service.AddAsync(dto);

            // Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("Marca de auto agregada con éxito", result.Response);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound_WhenMarcaDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((MarcasAutosEntity)null);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Marca de auto no encontrada", result.Message);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsSuccess_WhenMarcaIsUpdated()
        {
            // Arrange
            var existing = new MarcasAutosEntity { Id = 1, Name = "Toyota", Description = "Auto", IsActive = true };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existing);
            _mockRepo.Setup(r => r.UpdateAsync(It.IsAny<MarcasAutosEntity>())).ReturnsAsync(true);

            var dto = new MarcaAutoDto { Name = "Toyota Updated", Description = "Auto", IsActive = true };

            // Act
            var result = await _service.UpdateAsync(1, dto);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Marca de auto actualizada con éxito", result.Response);
        }
    }
}