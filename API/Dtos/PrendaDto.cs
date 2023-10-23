using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PrendaDto
{
    public int Id { get; set; }
    [Required]
    public int IdPrenda { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public double ValorUnitCOP { get; set; }
    [Required]
    public double ValorUnitUSD { get; set; }
    [Required]
    public int EstadoId { get; set; }
    [Required]
    public int TipoProteccionId { get; set; }
    [Required]
    public int GeneroId { get; set; }
}

public class PrendaOnlyDto
{
    public int IdPrenda { get; set; }
    public string Nombre { get; set; }
    public string TipoProteccion{ get; set; }

}