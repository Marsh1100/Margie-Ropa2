using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Inventario : BaseEntity
{
    public string CodInv { get; set; }
    public int PrendaId { get; set; }
    public Prenda Prenda { get; set; }
    public double ValorVentaCOP {get; set; }
    public double ValorVentaUSD {get; set; }

    public ICollection<InventarioTalla> InventarioTallas { get; set; }
    public ICollection<Talla> Tallas { get; set; } = new HashSet<Talla>();
     


}
