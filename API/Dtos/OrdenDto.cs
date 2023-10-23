using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class OrdenDto
{
    public int Id { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public int EmpleadoId { get; set; }    
    [Required]
    public int ClienteId { get; set; }
    [Required]
    public int EstadoId { get; set; }
 
}