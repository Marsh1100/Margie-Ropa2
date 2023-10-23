using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly ApiDbContext _context;

    public VentaRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
