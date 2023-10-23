using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DetalleVenta : BaseEntity
{
    public int VentaId { get; set; }
    public Venta Venta { get; set; }
    public int PrendaId { get; set; }
    public Prenda Prenda { get; set; }
    public int TallaId { get; set; }
    public Talla Talla { get; set; }
    public int Cantidad { get; set; }
    public double ValorUnitCOP { get; set; }
    
}
