using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApiDbContextSeed
{
    public static async Task SeedAsync(ApiDbContext context, ILoggerFactory loggerFactory)
    {
         try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Rol>
                {
                    new() { Name = "Administrator" },
                    new() { Name = "Employee" },
                    new() { Name = "WithoutRol" }
                };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
            if (!context.Paises.Any())
            {
                var paises = new List<Pais>
                {
                    new() { Nombre = "Colombia" },
                };
                context.Paises.AddRange(paises);
                await context.SaveChangesAsync();
            }
            if (!context.Departamentos.Any())
            {
                var list = new List<Departamento>
                {
                    new() { Nombre = "Santander",
                            PaisId= 1},
                };
                context.Departamentos.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.Municipios.Any())
            {
                var municipios = new List<Municipio>
                {
                    new() { Nombre = "Bucaramanga",
                            DepartamentoId= 1},
                    new() { Nombre = "Floridablanca",
                            DepartamentoId= 1},
                    new() { Nombre = "Giron",
                            DepartamentoId= 1}
                };
                context.Municipios.AddRange(municipios);
                await context.SaveChangesAsync();
            }
            if (!context.TipoPersonas.Any())
            {
                var list = new List<TipoPersona>
                {
                    new() { Nombre = "Natural" },
                    new() { Nombre = "Jurídica" }

                };
                context.TipoPersonas.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.TipoProteciones.Any())
            {
                var list = new List<TipoProteccion>
                {
                    new() { Descripcion = "Fuego" },
                    new() { Descripcion = "Voltaje" }

                };
                context.TipoProteciones.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.TipoEstados.Any())
            {
                var list = new List<TipoEstado>
                {
                    new() { Descripcion = "Produccion" },
                    new() { Descripcion = "Completo" }
                };
                context.TipoEstados.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.Estados.Any())
            {
                var list = new List<Estado>
                {
                    new() { Codigo = "Naranja",
                            TipoEstadoId = 1},
                    new() { Codigo = "Verde",
                            TipoEstadoId = 2 }
                };
                context.Estados.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.Generos.Any())
            {
                var list = new List<Genero>
                {
                    new() { Descripcion = "UniSex" },
                    new() { Descripcion = "Femenino" },
                    new() { Descripcion = "Masculino" }

                };
                context.Generos.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.Colores.Any())
            {
                var list = new List<Color>
                {
                    new() { Descripcion = "Azul" },
                    new() { Descripcion = "Negro" },
                    new() { Descripcion = "Amarillo" },
                    new() { Descripcion = "Naranja" }


                };
                context.Colores.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.Cargos.Any())
            {
                var list = new List<Cargo>
                {
                    new() { Descripcion = "Auxiliar de Bodega",
                            SueldoBase = 20000000},
                    new() { Descripcion = "Jefe de Producción",
                            SueldoBase = 30000000},                    
                    new() { Descripcion = "Secretaria",
                            SueldoBase = 20000000},
                };
                context.Cargos.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.FormaPagos.Any())
            {
                var list = new List<FormaPago>
                {
                    new() { Descripcion = "Efectivo" },
                    new() { Descripcion = "Transferencia" }

                };
                context.FormaPagos.AddRange(list);
                await context.SaveChangesAsync();
            }
            if (!context.Tallas.Any())
            {
                var list = new List<Talla>
                {
                    new() { Descripcion = "6" },
                    new() { Descripcion = "8" },
                    new() { Descripcion = "10" },
                    new() { Descripcion = "12" }

                };
                context.Tallas.AddRange(list);
                await context.SaveChangesAsync();
            }
            
        }catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiDbContext>();
            logger.LogError(ex.Message);
        }

        try
        {
            if(!context.Users.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/user.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<User>();
                        List<User> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new User
                            {
                                Id = item.Id,
                                IdenNumber = item.IdenNumber,
                                UserName=item.UserName,
                                Email = item.Email,
                                Password = item.Password
                            });
                        }
                        context.Users.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.Proveedores.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/proveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Proveedor>();
                        List<Proveedor> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Proveedor
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                NitProveedor = item.NitProveedor,
                                TipoPersonaId=item.TipoPersonaId,
                                MunicipioId = item.MunicipioId
                            });
                        }
                        context.Proveedores.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.Empleados.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/empleado.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Empleado>();
                        List<Empleado> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Empleado
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                IdEmp = item.IdEmp,
                                CargoId=item.CargoId,
                                FechaIngreso = item.FechaIngreso,
                                MunicipioId = item.MunicipioId
                            });
                        }
                        context.Empleados.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.Clientes.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/cliente.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Cliente>();
                        List<Cliente> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Cliente
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                IdCliente = item.IdCliente,
                                TipoPersonaId=item.TipoPersonaId,
                                FechaRegistro = item.FechaRegistro,
                                MunicipioId = item.MunicipioId
                            });
                        }
                        context.Clientes.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.UserRoles.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/userrol.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<UserRol>();
                        List<UserRol> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new UserRol
                            {
                                UserId= item.UserId,
                                RolId = item.RolId
                            });
                        }
                        context.UserRoles.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.Prendas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/prenda.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Prenda>();
                        List<Prenda> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Prenda
                            {
                                IdPrenda= item.IdPrenda,
                                Nombre = item.Nombre,
                                ValorUnitCOP = item.ValorUnitCOP,
                                ValorUnitUSD = item.ValorUnitUSD,
                                EstadoId = item.EstadoId,
                                TipoProteccionId = item.TipoProteccionId,
                                GeneroId = item.GeneroId
                            });
                        }
                        context.Prendas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
                
            }
            if(!context.Ordenes.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/orden.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Orden>();
                        List<Orden> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Orden
                            {
                                Fecha= item.Fecha,
                                EmpleadoId = item.EmpleadoId,
                                ClienteId = item.ClienteId,
                                EstadoId = item.EstadoId
                            });
                        }
                        context.Ordenes.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.DetalleOrdenes.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/detalleOrden.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<DetalleOrden>();
                        List<DetalleOrden> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new DetalleOrden
                            {
                                OrdenId= item.OrdenId,
                                PrendaId = item.PrendaId,
                                ColorId = item.ColorId,
                                CantidadProducida = item.CantidadProducida
                            });
                        }
                        context.DetalleOrdenes.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
                
            }
            if(!context.Ventas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/venta.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Venta>();
                        List<Venta> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Venta
                            {
                                Fecha= item.Fecha,
                                EmpleadoId = item.EmpleadoId,
                                ClienteId = item.ClienteId,
                                FormaPagoId = item.FormaPagoId
                            });
                        }
                        context.Ventas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
                
            }
            if(!context.Inventarios.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/inventario.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Inventario>();
                        List<Inventario> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Inventario
                            {
                                CodInv= item.CodInv,
                                PrendaId = item.PrendaId,
                                ValorVentaCOP = item.ValorVentaCOP,
                                ValorVentaUSD = item.ValorVentaUSD
                            });
                        }
                        context.Inventarios.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
                
            }

            if(!context.InventarioTallas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/inventarioTalla.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<InventarioTalla>();
                        List<InventarioTalla> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new InventarioTalla
                            {
                                InventarioId= item.InventarioId,
                                TallaId = item.TallaId,
                                Cantidad = item.Cantidad,
                            });
                        }
                        context.InventarioTallas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
                
            }

            if(!context.DetalleVentas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/detalleVenta.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<DetalleVenta>();
                        List<DetalleVenta> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new DetalleVenta
                            {
                                VentaId= item.VentaId,
                                PrendaId = item.PrendaId,
                                TallaId = item.TallaId,
                                Cantidad = item.Cantidad,
                                ValorUnitCOP = item.ValorUnitCOP
                            });
                        }
                        context.DetalleVentas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
                
            }
            if(!context.Insumos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/insumo.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Insumo>();
                        List<Insumo> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new Insumo
                            {
                                Nombre= item.Nombre,
                                ValorUnit = item.ValorUnit,
                                StockMin = item.StockMin,
                                StockMax = item.StockMax,
                            });
                        }
                        context.Insumos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
                
            }

            if(!context.InsumoProveedores.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/insumoProveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<InsumoProveedor>();
                        List<InsumoProveedor> entidad = new();
                        foreach (var item in list)
                        {
                            entidad.Add(new InsumoProveedor
                            {
                                InsumoId= item.InsumoId,
                                ProveedorId = item.ProveedorId
                            });
                        }
                        context.InsumoProveedores.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
                
            }
        }catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiDbContext>();
            logger.LogError(ex.Message);
        }
        
    } 
}
