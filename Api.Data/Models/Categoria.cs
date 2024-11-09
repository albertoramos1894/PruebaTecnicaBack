﻿using System;
using System.Collections.Generic;

namespace Api.Data.Models;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual ICollection<CostoPlaza> CostoPlazas { get; set; } = new List<CostoPlaza>();
}
