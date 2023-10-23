using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ClienteDto
{
    public int Id { get; set; }
    [Required]
    public string IdCliente { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public int TipoPersonaId { get; set; }
    [Required]
    public int MunicipioId { get; set; }
    [Required]
    public DateTime FechaRegistro { get; set; }

}