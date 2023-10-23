using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly ApiDbContext _context;

    public DepartamentoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
