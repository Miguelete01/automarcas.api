using Autos.Api.Dtos;
using Autos.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasAutosController : ControllerBase
    {
        private readonly IMarcasAutosService _marcasAutosService;

        public MarcasAutosController(IMarcasAutosService marcasAutosService)
        {
            _marcasAutosService = marcasAutosService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _marcasAutosService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _marcasAutosService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] MarcaAutoDto marcaAutoDto)
        {
            var response = await _marcasAutosService.AddAsync(marcaAutoDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] MarcaAutoDto marcaAutoDto)
        {
            var response = await _marcasAutosService.UpdateAsync(id, marcaAutoDto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
