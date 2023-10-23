using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class EmpresaRepository : GenericRepository<Empresa>, IEmpresa
{
    private readonly ApiDbContext _context;

    public EmpresaRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
