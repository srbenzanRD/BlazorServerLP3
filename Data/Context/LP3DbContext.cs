using LP3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LP3.Data.Context;

public class LP3DbContext:DbContext,ILP3DbContext
{
    public LP3DbContext(DbContextOptions options):base(options)
    {
        
    }
    public virtual DbSet<Producto> Productos {get; set;} = null!;
    public virtual DbSet<VehiculoMarca> Marcas {get; set;} = null!;
    public virtual DbSet<VehiculoModelo> Modelos {get; set;} = null!;
    public virtual DbSet<Vehiculo> Vehiculos {get; set;} = null!;
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}

public interface ILP3DbContext
{
    public DbSet<Producto> Productos {get; set;}
    public  DbSet<VehiculoMarca> Marcas {get; set;}
    public  DbSet<VehiculoModelo> Modelos {get; set;}
    public  DbSet<Vehiculo> Vehiculos {get; set;}

    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}