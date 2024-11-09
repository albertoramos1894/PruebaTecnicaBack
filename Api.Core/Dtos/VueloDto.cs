using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Dtos
{
    public class VueloDto
    {
        public string Codigo {  get; set; } = string.Empty;
        public int AeropuertoOrigenId { get; set; }
        public int AeropuertoDestinoId { get; set; }
        public DateOnly Fecha {  get; set; }
        public TimeOnly Hora {  get; set; }
        public int AerolineaId { get; set; }
    }
}
