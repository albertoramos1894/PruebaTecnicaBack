using Api.Core.Dtos;
using Api.Core.Interfaces;
using Api.Core.Requests;
using Api.Core.Responses;
using Api.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Modulos
{
    public class CatalogoServices : ICatalogosServices
    {
        private readonly IMapper _mapper;
        private readonly AgenciaVuelosContext _context;
        public CatalogoServices(IMapper mapper, AgenciaVuelosContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GeneralResponse<List<AeropuertoDto>>> GetAeropuertos()
        {
            GeneralResponse<List<AeropuertoDto>> response;
            List<AeropuertoDto> listAeropuertos = new List<AeropuertoDto>();
            try
            {
                List<Aeropuerto> aeropuertos = await _context.Aeropuertos.ToListAsync();                
                foreach (var aeropuerto in aeropuertos) 
                {
                    listAeropuertos.Add(_mapper.Map<AeropuertoDto>(aeropuerto));
                }

                response = new GeneralResponse<List<AeropuertoDto>>() { Success = true, Code = (int)HttpStatusCode.OK, Message = "Se recupero la lista de aeropuertos.", Data = listAeropuertos };
            }
            catch (Exception ex)
            {
                response = new GeneralResponse<List<AeropuertoDto>>()
                {
                    Success = false,
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio el siguiente error: " + ex.Message
                };
            }
            return response;
        }

        public async Task<GeneralResponse<List<AerolineaDto>>> GetAerolineas()
        {
            GeneralResponse<List<AerolineaDto>> response;
            List<AerolineaDto> listAerolineas = new List<AerolineaDto>();
            try
            {
                List<Aerolinea> aeropuertos = await _context.Aerolineas.ToListAsync();
                foreach (var aerolinea in aeropuertos)
                {
                    listAerolineas.Add(_mapper.Map<AerolineaDto>(aerolinea));
                }

                response = new GeneralResponse<List<AerolineaDto>>() { Success = true, Code = (int)HttpStatusCode.OK, Message = "Se recupero la lista de aerolineas.", Data = listAerolineas };
            }
            catch (Exception ex)
            {
                response = new GeneralResponse<List<AerolineaDto>>()
                {
                    Success = false,
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio el siguiente error: " + ex.Message
                };
            }
            return response;
        }

        public async Task<GeneralResponse<List<CategoriaDto>>> GetCategorias()
        {
            GeneralResponse<List<CategoriaDto>> response;
            List<CategoriaDto> listCategorias = new List<CategoriaDto>();
            try
            {
                List<Categoria> categorias = await _context.Categorias.ToListAsync();
                foreach (var categoria in categorias)
                {
                    listCategorias.Add(_mapper.Map<CategoriaDto>(categoria));
                }

                response = new GeneralResponse<List<CategoriaDto>>() { Success = true, Code = (int)HttpStatusCode.OK, Message = "Se recupero la lista de categorias.", Data = listCategorias };
            }
            catch (Exception ex)
            {
                response = new GeneralResponse<List<CategoriaDto>>()
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