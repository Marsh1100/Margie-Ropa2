using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ProveedorDto
{
    public int Id { get; set; }
    [Required]
    public string NitProveedor { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public int TipoPersonaId { get; set; }
    [Required]
    public int MunicipioId { get; set; }

}
public class ProveedorTipoDto
{
    public string NitProveedor { get; set; }
    public string Nombre { get; set; }
    public string TipoPersona { get; set; }
    public string Municipio { get; set; }

}