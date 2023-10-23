using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class GeneroRepository : GenericRepository<Genero>, IGenero
{
    private readonly ApiDbContext _context;

    public GeneroRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
