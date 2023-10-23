using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DetalleOrden : BaseEntity
{
    public int OrdenId { get; set; }
    public Orden Orden { get; set; }
    public int PrendaId { get; set; }
    public Prenda Prenda { get; set; }
    public int ColorId { get; set; }
    public Color Color { get; set; }
    public int CantidadProducida { get; set; }
  
    
}
