using LP3.Data.Context;
using LP3.Data.Models;
namespace LP3.Data.Services;

public class ProductoService
{
    private readonly ILP3DbContext _context;
    public ProductoService(ILP3DbContext context)
    {
        this._context = context;
    }

    public async Task<Result<int>> Crear(string nombre, string descripcion, double precio)
    {
        try
        {
            var producto = Producto.Crear(nombre, descripcion, precio);
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return Result<int>.Success(producto.productoID);
        }
        catch (Exception E)
        {
            return Result<int>.Failed(E.Message);
        }
    }
}

public interface IProductoService
{
    public Task<Result<int>> Crear(string nombre, string descripcion, double precio);
}