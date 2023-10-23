using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class InsumoPrenda
{
    public int InsumoId { get; set; }
    public Insumo Insumo { get; set; }
    public int PrendaId { get; set; }
    public Prenda Prenda { get; set; }
    public int Cantidad {   get; set; }
}
