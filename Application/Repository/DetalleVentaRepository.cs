using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVenta
{
    private readonly ApiDbContext _context;

    public DetalleVentaRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<string> RegisterAsync(int ventaId, int prendaId, int tallaId, int cantidad)
    {
        var invTallaExist = await _context.InventarioTallas
                            .Include(p=> p.Inventario)
                            .Where(p=> p.TallaId == tallaId && p.Inventario.PrendaId == prendaId)
                            .FirstAsync();
       
        if(invTallaExist != null)
        {
            if(invTallaExist.Cantidad >= cantidad){

                DetalleVenta newDetalleVenta =  new()
                {
                    VentaId =  ventaId,
                    PrendaId = prendaId,
                    TallaId = tallaId,
                    Cantidad = cantidad,
                    ValorUnitCOP = invTallaExist.Inventario.ValorVentaCOP
                };

                _context.DetalleVentas.Add(newDetalleVenta);
                await _context.SaveChangesAsync();

                invTallaExist.Cantidad -= cantidad;
                _context.InventarioTallas.Update(invTallaExist);
                await _context.SaveChangesAsync();

            }else{
                return "No hay suficientes unidades disponibles";
            }

        return $"Detalle agregado con exito a la venta {ventaId}";
        }
         return "No se encuentras unidades registradas en el inventario con esa talla";
        

        
    }
}
