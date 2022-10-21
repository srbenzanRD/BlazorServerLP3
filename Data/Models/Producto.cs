using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; }= null!;
    public double Precio { get; set; }
}