using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class MunicipioRepository : GenericRepository<Municipio>, IMunicipio
{
    private readonly ApiDbContext _context;

    public MunicipioRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
