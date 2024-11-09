using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Dtos
{
    public class ItininerarioVueloDto
    {
        public int ItininerarioId { get; set; } = 0;
        public int VueloId { get; set; }
        public int? Orden {  get; set; }
    }
}
