using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Talla : BaseEntity
{
   public string Descripcion { get; set; }
   public ICollection<DetalleVenta> DetalleVentas {get; set;}
   public ICollection<InventarioTalla> InventarioTallas { get; set; }
   public ICollection<Inventario> Inventarios { get; set; } = new HashSet<Inventario>();

}
