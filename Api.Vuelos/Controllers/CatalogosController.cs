using Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ILogger<CatalogosController> _logger;
        private readonly ICatalogosServices _services;

        public CatalogosController(ILogger<CatalogosController> logger, ICatalogosServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet]
        [Route("GetAeropuertos")]
        public async Task<IActionResult> GetAeropuertos()
        {
            var response = await _services.GetAeropuertos();

            return StatusCode(response.Code,response);
        }

        [HttpGet]
        [Route("GetAerolineas")]
        public async Task<IActionResult> GetAerolineas()
        {
            var response = await _services.GetAerolineas();

            return StatusCode(response.Code, response);
        }

        [HttpGet]
        [Route("GetCategorias")]
        public async Task<IActionResult> GetCategorias()
        {
            var response = await _services.GetCategorias();

            return StatusCode(response.Code, response);
        }
    }
}
