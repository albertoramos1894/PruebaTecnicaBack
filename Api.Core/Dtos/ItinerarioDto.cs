using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Dtos
{
    public class ItinerarioDto
    {
        public int ItinerarioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
        public int OrigenId { get; set; }
        public int DestinoId {  get; set; }
    }
}
