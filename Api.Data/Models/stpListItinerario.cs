using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public partial class stpListItinerario
    {
        public int ItinerarioId { get; set; }

        public string Nombre { get; set; } = null!;

        public DateOnly Fecha { get; set; }

        public int OrigenId { get; set; }
        public string Origen { get; set; }
        public string CodigoOrigen {  get; set; }
        public int DestinoId { get; set; }
        public string Destino { get; set; }
        public string CodigoDestino { get; set; }
    }
}
