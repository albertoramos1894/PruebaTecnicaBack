using Api.Core.Dtos;
using Api.Core.Interfaces;
using Api.Core.Requests;
using Api.Core.Responses;
using Api.Data.Models;
using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Api.Services.Modulos
{
    public class VuelosServices : IVuelosServices
    {
        private readonly IMapper _mapper;
        private readonly AgenciaVuelosContext _context;
        public VuelosServices(IMapper mapper, AgenciaVuelosContext context) 
        { 
            _mapper = mapper;
            _context = context;
        }
        public async Task<GeneralResponse<Object>> InsertVueloCostos(VueloRequest request)
        {
            GeneralResponse<object> response;
            try
            {
                Vuelo vuelo = _mapper.Map<Vuelo>(request.Vuelo);                
                _context.Vuelos.Add(vuelo);
                await _context.SaveChangesAsync();

                Aerolinea aerolinea = await _context.Aerolineas.FirstAsync(x=>x.AerolineaId == vuelo.AerolineaId);
                vuelo.Codigo = String.Concat(aerolinea.Abreviatura,"-",vuelo.VueloId);
                _context.Vuelos.Update(vuelo);

                foreach (var costo in request.Costos)
                {
                    CostoPlaza costoPlaza = _mapper.Map<CostoPlaza>(costo);
                    costoPlaza.VueloId = vuelo.VueloId;
                    costoPlaza.Vuelo = vuelo;
                    _context.CostoPlazas.Add(costoPlaza);
                }                

                await _context.SaveChangesAsync();

                response = new GeneralResponse<object>() { Success = true, Code = (int)HttpStatusCode.Created, Message = "Registro exitoso." };
            }
            catch (Exception ex) 
            {
                response = new GeneralResponse<object>()
                {
                    Success = false,
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio el siguiente error: " + ex.Message
                };
            }
            return response;
        }

        public async Task<GeneralResponse<List<StpListVuelosDto>>> ListVuelos()
        {
            GeneralResponse<List<StpListVuelosDto>> response;
            List<StpListVuelosDto> lstVuelos = new List<StpListVuelosDto>();
            try
            {

                List<StpListVuelos> result = await _context.stpListVuelos.FromSqlRaw("EXEC dbo.stpListVuelos").ToListAsync();

                foreach (StpListVuelos itinerario in result)
                {
                    lstVuelos.Add(_mapper.Map<StpListVuelosDto>(itinerario));
                }

                response = new GeneralResponse<List<StpListVuelosDto>>() { Success = true, Code = (int)HttpStatusCode.OK, Message = "Lista recuperada.", Data = lstVuelos };
            }
            catch (Exception ex)
            {
                response = new GeneralResponse<List<StpListVuelosDto>>()
                {
                    Success = false,
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio el siguiente error: " + ex.Message
                };
            }
            return response;
        }
    }
}
