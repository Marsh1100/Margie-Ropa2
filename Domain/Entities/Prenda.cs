using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Prenda : BaseEntity
{
    public int IdPrenda { get; set; }
    public string Nombre { get; set; }
    public double ValorUnitCOP { get; set; }
    public double ValorUnitUSD { get; set; }
    public int EstadoId { get; set; }
    public Estado Estado    { get; set; }
    public int TipoProteccionId  {get; set; }
    public TipoProteccion TipoProteccion { get; set;}
    public int GeneroId { get; set; }
    public Genero Genero { get; set; }

    public ICollection<DetalleOrden> DetalleOrdenes { get; set; }
    public ICollection<DetalleVenta> DetalleVentas { get; set; }
    public ICollection<Inventario> Inventarios { get; set; }
    public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
    public ICollection<Insumo> Insumos { get; set; }

}
