using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    private IProveedor _proveedor;
    private ITipoPersona _tipoPersona;
    private IMunicipio _municipio;
    private IPrenda _prendas;
    private ICliente _clientes; 
    private IEmpleado _empleado; 
    private IOrden _orden; 
    private IDetalleOrden _detalleOrden; 
    private IVenta _venta;
    private IInventario _inventario;
    private IDetalleVenta _detalleventa;
    private IInsumo _insumos;

    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }
    public IInsumo Insumos
    {
         get
        {
            if (_insumos == null)
            {
                _insumos = new InsumoRepository(_context);
            }
            return _insumos;
        }
    }
    public IDetalleVenta DetalleVentas
    {
        get
        {
            if (_detalleventa == null)
            {
                _detalleventa = new DetalleVentaRepository(_context);
            }
            return _detalleventa;
        }
    }
    public IInventario Inventarios
    {
        get
        {
            if (_inventario == null)
            {
                _inventario = new InventarioRepository(_context);
            }
            return _inventario;
        }
    }
    public IVenta Ventas
    {
        get
        {
            if (_venta == null)
            {
                _venta = new VentaRepository(_context);
            }
            return _venta;
        }
    }
    public ICliente Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }
    public IEmpleado Empleados
    {
        get
        {
            if (_empleado == null)
            {
                _empleado = new EmpleadoRepository(_context);
            }
            return _empleado;
        }
    }
     public IOrden Ordenes
    {
        get
        {
            if (_orden == null)
            {
                _orden = new OrdenRepository(_context);
            }
            return _orden;
        }
    }
     public IDetalleOrden DetalleOrdenes
    {
        get
        {
            if (_detalleOrden == null)
            {
                _detalleOrden = new DetalleOrdenRepository(_context);
            }
            return _detalleOrden;
        }
    }
    public IPrenda Prendas
    {
        get
        {
            if (_prendas == null)
            {
                _prendas = new PrendaRepository(_context);
            }
            return _prendas;
        }
    }
    public IMunicipio Municipios
    {
        get
        {
            if (_municipio == null)
            {
                _municipio = new MunicipioRepository(_context);
            }
            return _municipio;
        }
    }
    public ITipoPersona TipoPersonas
    {
        get
        {
            if (_tipoPersona == null)
            {
                _tipoPersona = new TipoPersonaRepository(_context);
            }
            return _tipoPersona;
        }
    }
    public IProveedor Proveedores
    {
        get
        {
            if (_proveedor == null)
            {
                _proveedor = new ProveedorRepository(_context);
            }
            return _proveedor;
        }
    }
    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }
    
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}