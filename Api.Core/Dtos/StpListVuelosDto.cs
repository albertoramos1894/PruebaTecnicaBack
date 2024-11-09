using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class StpListVuelosDto
    {
        public int VueloId { get; set; }

        public string Codigo { get; set; } = null!;

        public int AeropuertoOrigenId { get; set; }
        public string Origen {  get; set; } = null!;
        public string CodigoOrigen {  get; set; } = null!;
        public int AeropuertoDestinoId { get; set; }
        public string Destino { get; set; } = null!;
        public string CodigoDestino {  get; set; } = null!;

        public DateOnly Fecha { get; set; }

        public TimeOnly Hora { get; set; }

        public int AerolineaId { get; set; }
        public string Aerolinea { get; set; } = null!;
    }
}
