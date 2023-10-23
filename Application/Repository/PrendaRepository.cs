using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class PrendaRepository : GenericRepository<Prenda>, IPrenda
{
    private readonly ApiDbContext _context;

    public PrendaRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<object>> GetPrendas()
    {
        var prendas = await _context.Prendas.Include(p=>p.Genero).Include(p=>p.Estado).Include(p=>p.TipoProteccion)
                            .GroupBy(p=>p.TipoProteccion.Descripcion)
                            .Select(s=>new{
                                
                                TipoProteccion = s.Key,
                                Prendas  = s.Select(s=> new
                                         {
                                            s.Nombre,
                                            s.Genero.Descripcion,
                                            s.Estado.Codigo
                    
                                         }) 
                            }).ToArrayAsync();
        return prendas;
    
    }
}
