using Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Requests
{
    public class VueloRequest
    {        
        public VueloDto Vuelo {  get; set; }
        public List<CostoPlazasDto> Costos { get; set; }
    }
}
