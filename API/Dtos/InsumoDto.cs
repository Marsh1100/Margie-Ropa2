using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class InsumoDto
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public double ValorUnit { get; set; }
    [Required]
    public int StockMin {get; set; }
    [Required]
    public int StockMax {get; set; }
   
}
public class InsumoProveedorDto
{
    [Required]
    public int InsumoId { get; set; }

    [Required]
    public int ProveedorId { get; set; }
}

public class InsumoPrendaDto
{
    [Required]
    public int InsumoId { get; set; }
    [Required]
    public int PrendaId { get; set; }
    [Required]
    public int Cantidad {   get; set; }


}