using Domain.Entities;

namespace Domain.Interfaces;

public interface IDetalleVenta : IGenericRepository<DetalleVenta> { 
   Task<string> RegisterAsync(int ventaId, int prendaId, int tallaId, int cantidad); 
}

