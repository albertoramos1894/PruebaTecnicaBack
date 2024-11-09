using Api.Core.Dtos;
using Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Interfaces
{
    public interface ICatalogosServices
    {
        Task<GeneralResponse<List<AeropuertoDto>>> GetAeropuertos();
        Task<GeneralResponse<List<AerolineaDto>>> GetAerolineas();
        Task<GeneralResponse<List<CategoriaDto>>> GetCategorias();
    }
}
