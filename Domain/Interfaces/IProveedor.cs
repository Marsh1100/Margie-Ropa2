using Domain.Entities;

namespace Domain.Interfaces;

    public interface IProveedor : IGenericRepository<Proveedor> { 
        
        Task<IEnumerable<Proveedor>> GetProveedorNatural();
        Task<object> GetInsumos(string nit);
    }

