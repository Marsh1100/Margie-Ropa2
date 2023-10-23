using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Empresa : BaseEntity
{
    public string NIT { get; set; }
    public string RazonSocial { get; set; }
    public string RepresntanteLegal { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int MunicipioId { get; set; }
    public Municipio Municipio { get; set; }

}
