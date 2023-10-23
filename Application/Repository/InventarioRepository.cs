using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class InventarioRepository : GenericRepository<Inventario>, IInventario
{
    private readonly ApiDbContext _context;

    public InventarioRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<string> AddInventarioTalla(int invId, int tallaId, int cant)
    {
        var prendaExist = await _context.Inventarios.Include(p=>p.Prenda).Where(p=> p.Id == invId).FirstAsync();
        var tallaExist = await _context.Tallas.Where(p=>p.Id == tallaId).FirstAsync();

        if(prendaExist == null || tallaExist == null)
        {
            return "Verifique sí el Id inevtario o Id Talla exista en la BD.";
        }
        InventarioTalla newInvTalla = new(){
            InventarioId = invId,
            TallaId = tallaId,
            Cantidad = cant
        };

        _context.InventarioTallas.Add(newInvTalla);
        await _context.SaveChangesAsync();
        return $"Se ha agregado nuevas prendas de tipo {prendaExist.Prenda.Nombre} de la talla {tallaExist.Descripcion}.";
    }
}
