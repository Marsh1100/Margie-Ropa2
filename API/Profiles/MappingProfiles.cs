using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>()
            .ReverseMap();
        CreateMap<Rol, RolDto>()
            .ForMember(dest=>dest.Rol, origen=> origen.MapFrom(origen=> origen.Name.ToString()))
            .ReverseMap();
        CreateMap<User,UserAllDto>()
            .ForMember(dest=>dest.Roles, origen=> origen.MapFrom(origen=> origen.Roles))
            .ReverseMap();
        CreateMap<Proveedor, ProveedorDto>()
            .ReverseMap();
        CreateMap<Proveedor, ProveedorTipoDto>()
            .ForMember(dest=>dest.TipoPersona, origen=> origen.MapFrom(origen=> origen.TipoPersona.Nombre))
            .ForMember(dest=>dest.Municipio, origen=> origen.MapFrom(origen=> origen.Municipio.Nombre))
            .ReverseMap();
        CreateMap<Prenda,PrendaDto>()
            .ReverseMap();
        CreateMap<Cliente,ClienteDto>()
            .ReverseMap();
        CreateMap<Empleado,EmpleadoDto>()
            .ReverseMap();
        CreateMap<Orden,OrdenDto>()
            .ReverseMap();
         CreateMap<DetalleOrden,DetalleOrdenDto>()
            .ReverseMap();
        CreateMap<Prenda,PrendaOnlyDto>()
            .ForMember(dest=>dest.TipoProteccion, origen=> origen.MapFrom(origen=> origen.TipoProteccion.Descripcion))
            .ReverseMap();
        CreateMap<Venta,VentaDto>()
            .ReverseMap();

        CreateMap<Inventario,InventarioDto>()
            .ReverseMap();
        CreateMap<InventarioTalla,InventarioTallaDto>()
            .ReverseMap();
        CreateMap<DetalleVenta, DetalleVentaDto>()
            .ReverseMap();
    }
}
