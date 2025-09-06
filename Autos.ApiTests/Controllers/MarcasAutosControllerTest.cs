using Autos.Api.Controllers;
using Autos.Api.Dtos;
using Autos.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Autos.ApiTests.Controllers
{
    public class MarcasAutosControllerTest
    {
        private readonly Mock<IMarcasAutosService> _mockService;
        private readonly MarcasAutosController _controller;

        public MarcasAutosControllerTest()
        {
            _mockService = new Mock<IMarcasAutosService>();
            _controller = new MarcasAutosController(_mockService.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkResult()
        {
            // Arrange
            var response = BaseResponse<IEnumerable<MarcaAutoDto>>.CreateSuccessResponse(
                new List<MarcaAutoDto>(), "Marcas de autos obtenidas con éxito", 200);
            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound_WhenMarcaDoesNotExist()
        {
            // Arrange
            var response = BaseResponse<MarcaAutoDto>.CreateErrorResponse("Marca de auto no encontrada", 404);
            _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(response);

            // Act
            var result = await _controller.GetByIdAsync(1);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(404, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddAsync_ReturnsCreated_WhenSuccessful()
        {
            // Arrange
            var dto = new MarcaAutoDto { Name = "Mazda", Description = "Auto" };
            var response = BaseResponse<string>.CreateSuccessResponse("Marca de auto agregada con éxito", "Marca de auto agregada con éxito", 201);
            _mockService.Setup(s => s.AddAsync(dto)).ReturnsAsync(response);

            // Act
            var result = await _controller.AddAsync(dto);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, objectResult.StatusCode);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var dto = new MarcaAutoDto { Name = "Mazda Updated", Description = "Auto" };
            var response = BaseResponse<string>.CreateSuccessResponse("Marca de auto actualizada con éxito", "Marca de auto actualizada con éxito", 200);
            _mockService.Setup(s => s.UpdateAsync(1, dto)).ReturnsAsync(response);

            // Act
            var result = await _controller.UpdateAsync(1, dto);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, objectResult.StatusCode);
        }
    }
}
