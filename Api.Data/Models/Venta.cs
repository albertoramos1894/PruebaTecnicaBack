using System;
using System.Collections.Generic;

namespace Api.Data.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    public decimal TotalCompra { get; set; }

    public DateTime FechaCompra { get; set; }

    public int ClienteId { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Cliente Cliente { get; set; } = null!;
}
