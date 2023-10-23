using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Proveedor : BaseEntity
{
    public string NitProveedor { get; set; }
    public string Nombre { get; set; }
    public int TipoPersonaId  { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int MunicipioId { get; set; }
    public Municipio Municipio { get; set; }

    public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
    public ICollection<Insumo> Insumos { get; set; } = new HashSet<Insumo>();

}
