using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Dtos
{
    public class CostoPlazasDto
    {
        public int NumeroPlazas { get; set; }
        public int CategoriaId { get; set; }
        public decimal Costo {  get; set; }
    }
}
