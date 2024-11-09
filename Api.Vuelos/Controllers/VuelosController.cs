using Api.Core.Interfaces;
using Api.Core.Requests;
using Api.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Vuelos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VuelosController : ControllerBase
    {        

        private readonly ILogger<VuelosController> _logger;
        private readonly IVuelosServices _services;

        public VuelosController(ILogger<VuelosController> logger, IVuelosServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VueloRequest request)
        {
            var result = await _services.InsertVueloCostos(request);
            return StatusCode(result.Code,result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _services.ListVuelos();
            return StatusCode(result.Code, result);
        }
    }
}
