using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Orden : BaseEntity
{
    public DateTime Fecha { get; set; }
    public int EmpleadoId { get; set; }
    public Empleado Empleado { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public int EstadoId { get; set; }
    public Estado Estado    { get; set; }
    public ICollection<DetalleOrden> DetalleOrdenes { get; set; }
    
}
