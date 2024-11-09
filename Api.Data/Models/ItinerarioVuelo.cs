using System;
using System.Collections.Generic;

namespace Api.Data.Models;

public partial class ItinerarioVuelo
{
    public int ItinerarioId { get; set; }

    public int VueloId { get; set; }

    public int? Orden { get; set; }

    public virtual Itinerario Itinerario { get; set; } = null!;

    public virtual Vuelo Vuelo { get; set; } = null!;
}
