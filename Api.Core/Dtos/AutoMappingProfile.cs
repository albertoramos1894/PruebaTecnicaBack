using Api.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Dtos
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile() 
        {
            CreateMap<VueloDto, Vuelo>();
            CreateMap<CostoPlazasDto, CostoPlaza>();
            CreateMap<ItinerarioDto, Itinerario>();
            CreateMap<ItininerarioVueloDto, ItinerarioVuelo>();
            CreateMap<Aerolinea, AerolineaDto>();
            CreateMap<Aeropuerto, AeropuertoDto>();
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<stpListItinerario, stpListItinerarioDto>();
            CreateMap<StpListVuelos, StpListVuelosDto>();
        }    
    }
}
