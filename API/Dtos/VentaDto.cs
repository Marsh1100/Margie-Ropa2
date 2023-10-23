using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class VentaDto
{
    public int Id { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public int EmpleadoId  { get; set; }
    [Required]
    public int ClienteId { get; set; }
    [Required]
    public int FormaPagoId { get; set; }
}
public class DetalleVentaDto
{
    public int Id { get; set; }
    [Required]
    public int VentaId { get; set; }
    [Required]
    public int PrendaId { get; set; }
    [Required]
    public int TallaId { get; set; }
    [Required]
    public int Cantidad { get; set; }

    public double ValorUnitCOP { get; set; }

}