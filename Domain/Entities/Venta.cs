using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Venta : BaseEntity
{
    public DateTime Fecha { get; set; }
    public int EmpleadoId  { get; set; }
    public Empleado Empleado { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public int FormaPagoId { get; set; }
    public FormaPago FormaPago{ get; set; }
    
    public ICollection<DetalleVenta> DetalleVentas { get; set; }
    
}
