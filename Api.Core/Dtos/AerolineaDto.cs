using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Dtos
{
    public class AerolineaDto
    {
        public int AerolineaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Abreviatura {  get; set; } = string.Empty;
    }
}
