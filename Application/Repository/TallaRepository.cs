using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TallaRepository : GenericRepository<Talla>, ITalla
{
    private readonly ApiDbContext _context;

    public TallaRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
