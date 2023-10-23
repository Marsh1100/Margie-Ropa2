using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUserRepository Users { get; }
    IProveedor Proveedores { get; }
    ITipoPersona TipoPersonas { get; }
    IMunicipio Municipios { get; }
    IPrenda Prendas { get; }

    ICliente Clientes { get; }
    IEmpleado Empleados { get; }
    IOrden Ordenes { get; }
    IDetalleOrden DetalleOrdenes { get; }
    IVenta Ventas { get; }

    IInventario Inventarios { get; }
    IDetalleVenta DetalleVentas { get; }

    Task<int> SaveAsync();
}
