using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly ApiDbContext _context;

    public EmpleadoRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<object> GetVentas(int id)
    {
        var empleado = await _context.Empleados
                        .Include(p=>p.Ventas).ThenInclude(p=> p.DetalleVentas)
                        .Where(p=> p.Id == id)
                        .Select(s=> new{
                            IdEmpleado = s.IdEmp,
                            s.Nombre,
                            Facturas = s.Ventas.Select(d=> new
                            {
                                NroFactura = d.Id,
                                d.Fecha,
                                TotalFactura = d.DetalleVentas.Sum(a=> a.Cantidad * a.ValorUnitCOP)
                            })
                        }).FirstAsync();
        return empleado;
    }
}
