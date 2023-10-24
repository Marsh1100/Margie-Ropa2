using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly ApiDbContext _context;

    public ProveedorRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<object> GetInsumos(string nit)
    {
       var provedor = await _context.Proveedores
                        .Include(p=>p.Insumos)
                        .Where(p=> p.NitProveedor == nit)
                        .Select(s=> new
                            {
                                Proveedor = s.Nombre,
                                NIT = s.NitProveedor,
                                Insumos = s.Insumos.Select(x=>new
                                {
                                    Insumo = x.Nombre,
                                    ValorUnit = x.ValorUnit
                                })
                            }
                        ).FirstAsync();
        return provedor;
    }

    public async Task<IEnumerable<Proveedor>> GetProveedorNatural()
    {
        var proveedores = await _context.Proveedores
                                .Include(p=> p.Municipio)
                                .Include(p=> p.TipoPersona)
                                .Where(p=> p.TipoPersona.Nombre.ToLower() == "natural").ToListAsync();
        return proveedores;
    }
}
