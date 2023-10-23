using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DetalleOrdenRepository : GenericRepository<DetalleOrden>, IDetalleOrden
{
    private readonly ApiDbContext _context;

    public DetalleOrdenRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
