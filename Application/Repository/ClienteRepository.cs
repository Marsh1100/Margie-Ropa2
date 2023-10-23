using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly ApiDbContext _context;

    public ClienteRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<object> GetOrdenes(string idCliente)
    {
        var clientes = await _context.Clientes
                        .Include(p=> p.Ordenes).ThenInclude(p=> p.DetalleOrdenes)  
                        .Include(p=> p.Municipio)         
                        .ToListAsync();
        var ordenes = await _context.Ordenes.ToListAsync();
        var detOrdenes = await _context.DetalleOrdenes.ToListAsync();

        var prendas = await _context.Prendas.Include(p=>p.Estado).ThenInclude(p=>p.TipoEstado).ToListAsync();

        var clientePrendas = (from prenda in prendas
                                join detOrden in detOrdenes on prenda.Id equals detOrden.Id  
                                join orden in ordenes on detOrden.OrdenId equals orden.Id
                                join cliente in clientes on orden.ClienteId equals cliente.Id
                                where cliente.IdCliente == idCliente select cliente).Distinct() 
                                .Select(s=> new
                                {
                                    s.IdCliente,
                                    s.Nombre,
                                    Municipio = s.Municipio.Nombre,
                                    OrdenesProduccion = s.Ordenes.Select(d=> new {
                                        OrdenId = d.Id,
                                        d.Fecha,
                                        d.Estado.Codigo,
                                        Estado = d.Estado.TipoEstado.Descripcion,
                                        TotalOrden = d.DetalleOrdenes
                                                        .Sum(f=> f.CantidadProducida *
                                                            prendas.Where(p=> p.Id == f.PrendaId).Select(a=> a.ValorUnitCOP).First()),
                                        DetalleOrden = d.DetalleOrdenes.Select(r=> new
                                                                {
                                                                   Prenda = r.Prenda.Nombre,
                                                                   CodigoPrenda = r.Prenda.IdPrenda,
                                                                   Cantidad = r.CantidadProducida,
                                                                   r.Prenda.ValorUnitUSD,
                                                                   r.Prenda.ValorUnitCOP 
                                                                })
                                    })
                                    
                                });
        return  clientePrendas;                   

    }
}
