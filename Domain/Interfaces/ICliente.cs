using Domain.Entities;

namespace Domain.Interfaces;

public interface ICliente : IGenericRepository<Cliente> { 
    Task<object> GetOrdenes(string idCliente);
}

