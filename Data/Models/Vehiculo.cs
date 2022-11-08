using System.ComponentModel.DataAnnotations;

namespace  LP3.Data.Models;

public class Vehiculo
{
    public int Id { get; set; } 
    public VehiculoModelo Modelo { get; set; }
    public int Anio { get; set; }
}

public class VehiculoMarca
{
    public int Id { get; set; } 
    public string Nombre { get; set; }
}

public class VehiculoModelo
{
    public int Id { get; set; } 
    public int MarcaId { get; set; } 
    public virtual VehiculoMarca Marca { get; set; }
    public string Nombre { get; set; }
}