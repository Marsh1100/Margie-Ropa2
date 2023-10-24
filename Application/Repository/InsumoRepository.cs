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

    public async Task<string> AddInsumoPrenda(int insumoId, int prendaId, int cant)
    {
        var prendaExist = await _context.Prendas.Where(p=> p.Id == prendaId).FirstAsync();
        var insumoExist = await _context.Insumos.Where(p=>p.Id == insumoId).FirstAsync();

        if(prendaExist == null || insumoExist == null)
        {
            return "Verifique sí el Id insumo o Id prenda exista en la BD.";
        }
        InsumoPrenda newInsumoPrenda = new(){
            InsumoId = insumoId,
            PrendaId = prendaId,
            Cantidad = cant
        };

        _context.InsumoPrendas.Add(newInsumoPrenda);
        await _context.SaveChangesAsync();
        return $"Se ha agregado nuevos insumos del tipo {insumoExist.Nombre} para la fabricación de las prendas {prendaExist.Nombre}.";
    }
}
