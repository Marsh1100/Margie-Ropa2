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

    public async Task<IEnumerable<Proveedor>> GetProveedorNatural()
    {
        var proveedores = await _context.Proveedores
                                .Include(p=> p.Municipio)
                                .Include(p=> p.TipoPersona)
                                .Where(p=> p.TipoPersona.Nombre.ToLower() == "natural").ToListAsync();
        return proveedores;
    }
}
