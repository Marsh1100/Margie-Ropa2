using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class EmpleadoDto
{
    public int Id { get; set; }
    [Required]
    public string IdEmp { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public int CargoId  { get; set; }
    public DateTime FechaIngreso { get; set; }

    [Required]
    public int MunicipioId { get; set; }
    
}