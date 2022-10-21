using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class LP3DbContext:DbContext,ILP3DbContext
{
    public virtual DbSet<Producto> Productos {get;} = null!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}

public interface ILP3DbContext
{
    public DbSet<Producto> Productos {get;}
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}