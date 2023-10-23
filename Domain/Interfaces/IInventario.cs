using Domain.Entities;

namespace Domain.Interfaces;

public interface IInventario : IGenericRepository<Inventario> { 
    Task<string> AddInventarioTalla(int invId, int tallaId, int cant);
}

