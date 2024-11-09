using System;
using System.Collections.Generic;

namespace Api.Data.Models;

public partial class Aeropuerto
{
    public int AeropuertoId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Itinerario> ItinerarioDestinos { get; set; } = new List<Itinerario>();

    public virtual ICollection<Itinerario> ItinerarioOrigens { get; set; } = new List<Itinerario>();

    public virtual ICollection<Vuelo> VueloAeropuertoDestinos { get; set; } = new List<Vuelo>();

    public virtual ICollection<Vuelo> VueloAeropuertoOrigenNavigations { get; set; } = new List<Vuelo>();
}
