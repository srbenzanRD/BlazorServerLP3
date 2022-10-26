using System.ComponentModel.DataAnnotations;

namespace  LP3.Data.Models;

public class Producto
{
    [Key]
    public int productoID { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; }= null!;
    public double Precio { get; set; }

    public static Producto Crear(string nombre, string descripcion, double precio){
        return new Producto(){
            productoID = 0,
            Nombre= nombre,
            Descripcion = descripcion,
            Precio = precio
            };
    }
}