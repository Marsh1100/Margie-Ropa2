using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class EstadoRepository : GenericRepository<Estado>, IEstado
{
    private readonly ApiDbContext _context;

    public EstadoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
