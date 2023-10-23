using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class InventarioDto
{
    public int Id { get; set; }
    [Required]
    public string CodInv { get; set; }
    [Required]
    public int PrendaId { get; set; }
    [Required]
    public double ValorVentaCOP {get; set; }
    [Required]
    public double ValorVentaUSD {get; set; }

}

public class InventarioTallaDto
{
    public int InventarioId { get; set; }
    public int TallaId { get; set; }
    public int Cantidad { get; set; }



}