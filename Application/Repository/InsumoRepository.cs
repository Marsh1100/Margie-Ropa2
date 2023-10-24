using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class InsumoRepository : GenericRepository<Insumo>, IInsumo
{
    private readonly ApiDbContext _context;

    public InsumoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<string> AddInsumoProveedor(int insumoId, int proveedorId)
    {
        var insumoExist = await _context.Insumos.Where(x=> x.Id == insumoId).FirstAsync();
        var proveedorExist = await _context.Proveedores.Where(x=> x.Id == proveedorId).FirstAsync();

        if(insumoExist == null || proveedorExist == null)
        {
            return "Verifique sí el Id Insumo o Id Proveedor exista en la BD.";
        }
        InsumoProveedor newInsumoProveedor = new(){
            InsumoId = insumoId,
            ProveedorId = proveedorId
        };

        _context.InsumoProveedores.Add(newInsumoProveedor);
        await _context.SaveChangesAsync();
        return $"Se ha agregado nuevo insumo {insumoExist.Nombre} al proveedor {proveedorExist.Nombre}.";

    }
}
