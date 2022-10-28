using LP3.Data.Context;
using LP3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LP3.Data.Services;

public class ProductoService : IProductoService
{
    private readonly ILP3DbContext _context;

    public ProductoService(ILP3DbContext context)
    {
        _context = context;
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
    public async Task<Result<List<Producto>>> Consultar(string filtro = "")
    {
        try
        {
            
            var productos = await _context.Productos
            .Where(p=>p.Nombre.Contains(filtro))
            .ToListAsync();
            
            return Result<List<Producto>>.Success(productos);
        }
        catch (Exception E)
        {
            return Result<List<Producto>>.Failed(E.Message);
        }
    }

    public async Task Editar(int Id,string nombre, string descripcion, double precio){
        var producto = await _context.Productos
        .FirstOrDefaultAsync(p=>p.productoID == Id);
        if(producto!=null){
        producto.Update(nombre,descripcion,precio);
        await _context.SaveChangesAsync();
        }
    }
    public async Task Eliminar(int Id){
        var producto = await _context.Productos
        .FirstOrDefaultAsync(p=>p.productoID == Id);
        if(producto!=null){
        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        }
    }
}

public interface IProductoService
{
    public Task<Result<int>> Crear(string nombre, string descripcion, double precio);
    public Task<Result<List<Producto>>> Consultar(string filtro = "");
    public Task Editar(int Id,string nombre, string descripcion, double precio);
    public Task Eliminar(int Id);
}