using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TipoEstadoRepository : GenericRepository<TipoEstado>, ITipoEstado
{
    private readonly ApiDbContext _context;

    public TipoEstadoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
