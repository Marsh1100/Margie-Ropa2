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

    public async Task<object> GetInsumos(int idPrenda)
    {
        var insumosPrendas = await _context.InsumoPrendas.ToListAsync();
        var prendas = await _context.Prendas
                            .Include(x=> x.Insumos)
                            .ToListAsync();
        
        var insumos = (from prenda in prendas
                        join insumoPrenda in insumosPrendas on prenda.Id equals insumoPrenda.PrendaId
                        where prenda.Id == idPrenda
                        select prenda).Distinct()
                        .Select(j=> new {
                            j.Id,
                            Prenda = j.Nombre,
                            Insumos = j.InsumoPrendas.Select(n=> new{
                                NombreInsumo = n.Insumo.Nombre,
                                n.Insumo.ValorUnit,
                                n.Cantidad
                            }),
                            CostoTotal = j.InsumoPrendas.Sum(d=> d.Insumo.ValorUnit * d.Cantidad)
                        });
        return insumos;
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
