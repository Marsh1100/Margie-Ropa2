using Domain.Entities;

namespace Domain.Interfaces;

    public interface IInsumo : IGenericRepository<Insumo> { 
        Task<string> AddInsumoProveedor(int insumoId, int proveedorId);
        Task<string> AddInsumoPrenda(int insumoId,int prendaId, int cant);
    }

