using System;
using System.Collections.Generic;

namespace Api.Data.Models;

public partial class Vuelo
{
    public int VueloId { get; set; }

    public string Codigo { get; set; } = null!;

    public int AeropuertoOrigenId { get; set; }

    public int AeropuertoDestinoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public int AerolineaId { get; set; }

    public virtual Aeropuerto AeropuertoDestino { get; set; } = null!;

    public virtual Aerolinea AeropuertoOrigen { get; set; } = null!;

    public virtual Aeropuerto AeropuertoOrigenNavigation { get; set; } = null!;

    public virtual ICollection<CostoPlaza> CostoPlazas { get; set; } = new List<CostoPlaza>();

    public virtual ICollection<ItinerarioVuelo> ItinerarioVuelos { get; set; } = new List<ItinerarioVuelo>();
}
