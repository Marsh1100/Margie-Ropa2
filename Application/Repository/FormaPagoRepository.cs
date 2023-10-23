using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class FormaPagoRepository : GenericRepository<FormaPago>, IFormaPago
{
    private readonly ApiDbContext _context;

    public FormaPagoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
