using System;
using System.Collections.Generic;

namespace Api.Data.Models;

public partial class Boleto
{
    public int BoletoId { get; set; }

    public int ClienteId { get; set; }

    public int CategoriaId { get; set; }

    public DateTime FechaEmision { get; set; }

    public int ItinerarioId { get; set; }

    public decimal CostoTotal { get; set; }

    public int? VentaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Itinerario Itinerario { get; set; } = null!;

    public virtual Venta? Venta { get; set; }
}
