using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class OrdenRepository : GenericRepository<Orden>, IOrden
{
    private readonly ApiDbContext _context;

    public OrdenRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<object>> GetPrendas(int id)
    {
        var ordenes = await _context.Ordenes.ToListAsync();
        var detalleOrdenes = await _context.DetalleOrdenes.ToListAsync();
        var prendas = await _context.Prendas.Include(p=>p.Genero).Include(p=>p.TipoProteccion).ToListAsync();
        var estados = await _context.Estados.Include(p=>p.TipoEstado).ToListAsync();
        var tipoestados = await _context.TipoEstados.ToListAsync();

        var result = (from orden in ordenes
                    join detalleOrden in detalleOrdenes on orden.Id equals detalleOrden.OrdenId
                    join prenda in prendas on detalleOrden.PrendaId equals prenda.Id
                    join estado in estados on prenda.EstadoId equals estado.Id
                    join tipoestado in tipoestados on estado.Id equals tipoestado.Id
                    where orden.Id == id && tipoestado.Id == 1
                    select prenda
                    ).Select(s=> new
                    {
                        s.IdPrenda,
                        s.Nombre,
                        s.ValorUnitCOP,
                        s.ValorUnitUSD,
                        TipoProteccion = s.TipoProteccion.Descripcion,
                        Genero = s.Genero.Descripcion,
                        Estado = s.Estado.TipoEstado.Descripcion,
                    });
        return result;
    }
}
