using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class ColorRepository : GenericRepository<Color>, IColor
{
    private readonly ApiDbContext _context;

    public ColorRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
