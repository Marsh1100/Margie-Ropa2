using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class CargoRepository : GenericRepository<Cargo>, ICargo
{
    private readonly ApiDbContext _context;

    public CargoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
