using Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Requests
{
    public class ItinerarioRequest
    {
        public ItinerarioDto itinerario {  get; set; }
        public List<ItininerarioVueloDto> ItinerarioVuelos { get; set; }
    }
}
