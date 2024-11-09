﻿using Api.Core.Requests;
using Api.Core.Responses;
using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Interfaces
{
    public interface IVuelosServices
    {
        Task<GeneralResponse<Object>> InsertVueloCostos(VueloRequest request);
        Task<GeneralResponse<List<StpListVuelosDto>>> ListVuelos();
    }
}
