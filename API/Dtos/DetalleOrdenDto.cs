using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class DetalleOrdenDto
{
    public int Id { get; set; }
    [Required]
    public int OrdenId { get; set; }
    [Required]
    public int PrendaId { get; set; }
    [Required]
    public int ColorId { get; set; }
    public int CantidadProducida { get; set; }
 
}