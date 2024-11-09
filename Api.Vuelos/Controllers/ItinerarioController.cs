using Api.Core.Interfaces;
using Api.Core.Requests;
using Api.Vuelos.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItinerarioController : ControllerBase
    {
        private readonly ILogger<ItinerarioController> _logger;
        private readonly IItinerarioServices _services;

        public ItinerarioController(ILogger<ItinerarioController> logger, IItinerarioServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItinerarioRequest request)
        {
            var result = await _services.InsertItinerario(request);
            return StatusCode(result.Code, result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _services.ListItinerarios();
            return StatusCode(result.Code, result);
        }
    }
}
