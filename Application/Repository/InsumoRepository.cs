using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class InsumoRepository : GenericRepository<Insumo>, IInsumo
{
    private readonly ApiDbContext _context;

    public InsumoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
