using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly ApiDbContext _context;

    public ClienteRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
