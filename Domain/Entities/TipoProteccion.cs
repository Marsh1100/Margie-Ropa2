using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class TipoProteccion : BaseEntity
{
   public string Descripcion { get; set; }
   public ICollection<Prenda> Prendas {get; set;}
}
