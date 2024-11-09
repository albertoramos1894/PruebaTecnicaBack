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
    public class ItinerarioServices : IItinerarioServices
    {
        private readonly IMapper _mapper;
        private readonly AgenciaVuelosContext _context;
        public ItinerarioServices(IMapper mapper, AgenciaVuelosContext context) 
        { 
            _mapper = mapper;
            _context = context;
        }
        public async Task<GeneralResponse<List<stpListItinerarioDto>>> ListItinerarios()
        {
            GeneralResponse<List<stpListItinerarioDto>> response;
            List<stpListItinerarioDto> lstItinerarios = new List<stpListItinerarioDto>();
            try
            {

                List<stpListItinerario> result = await _context.StpListItinerarios.FromSqlRaw("EXEC dbo.stpListItinerarios").ToListAsync();      
                
                foreach(stpListItinerario itinerario in result)
                {
                    lstItinerarios.Add(_mapper.Map<stpListItinerarioDto>(itinerario));
                }

                response = new GeneralResponse<List<stpListItinerarioDto>>() { Success = true, Code = (int)HttpStatusCode.OK, Message = "Lista recuperada.", Data = lstItinerarios };
            }
            catch (Exception ex) 
            {
                response = new GeneralResponse<List<stpListItinerarioDto>>()
                {
                    Success = false,
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio el siguiente error: " + ex.Message
                };
            }
            return response;
        }

        public async Task<GeneralResponse<Object>> InsertItinerario(ItinerarioRequest request)
        {
            GeneralResponse<object> response;
            try
            {
                if (!ValidaItinerario(request.ItinerarioVuelos, request.itinerario.OrigenId, request.itinerario.DestinoId))
                {
                    response = new GeneralResponse<object>()
                    {
                        Success = false,
                        Code = (int)HttpStatusCode.InternalServerError,
                        Message = "El itinerario ingresado no es valido."
                    };
                    return response;
                }

                Itinerario itinerario = _mapper.Map<Itinerario>(request.itinerario);
                _context.Itinerarios.Add(itinerario);
                await _context.SaveChangesAsync();

                foreach (var vuelo in request.ItinerarioVuelos)
                {
                    ItinerarioVuelo itinerarioVuelo = _mapper.Map<ItinerarioVuelo>(vuelo);
                    itinerarioVuelo.ItinerarioId = itinerario.ItinerarioId;
                    _context.ItinerarioVuelos.Add(itinerarioVuelo);
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

        public bool ValidaItinerario(List<ItininerarioVueloDto> vuelos, int OrigenId, int DestinoId)
        {
            bool Valido = false;
            try
            {
                vuelos = vuelos.OrderBy(x=>x.Orden).ToList();
                Vuelo origen = _context.Vuelos.First(x=>x.VueloId == vuelos[0].VueloId);
                Vuelo destino = _context.Vuelos.First(x => x.VueloId == vuelos.Last().VueloId);

                Valido = origen.AeropuertoOrigenId == OrigenId && destino.AeropuertoDestinoId == DestinoId;
            }
            catch (Exception ex)
            {
            }
            return Valido;
        }
    }
}
