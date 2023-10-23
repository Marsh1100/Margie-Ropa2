using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TipoProteccionRepository : GenericRepository<TipoProteccion>, ITipoProteccion
{
    private readonly ApiDbContext _context;

    public TipoProteccionRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
