using System;
using System.Collections.Generic;

namespace Api.Data.Models;

public partial class CostoPlaza
{
    public int CostoId { get; set; }

    public int NumeroPlazas { get; set; }

    public int VueloId { get; set; }

    public int CategoriaId { get; set; }

    public decimal Costo { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Vuelo Vuelo { get; set; } = null!;
}
