using Domain.Entities;

namespace Domain.Interfaces;

    public interface IEmpleado : IGenericRepository<Empleado> { 
        Task<object> GetVentas(int id);
    }

