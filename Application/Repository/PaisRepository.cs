using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly ApiDbContext _context;

    public PaisRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
