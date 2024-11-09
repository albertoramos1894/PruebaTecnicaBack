using System;
using System.Collections.Generic;

namespace Api.Data.Models;

public partial class Itinerario
{
    public int ItinerarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public int OrigenId { get; set; }

    public int DestinoId { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Aeropuerto Destino { get; set; } = null!;

    public virtual ICollection<ItinerarioVuelo> ItinerarioVuelos { get; set; } = new List<ItinerarioVuelo>();

    public virtual Aeropuerto Origen { get; set; } = null!;
}
