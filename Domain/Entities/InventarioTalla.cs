using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class InventarioTalla 
{
    public int InventarioId { get; set; }
    public Inventario Inventario { get; set; }
    public int TallaId { get; set; }
    public Talla Talla { get; set; }
    public int Cantidad {   get; set; }
}
