using Microsoft.EntityFrameworkCore;
using WKTechnology.Domain.Entities;

namespace WKTechnology.Infra.Context;

public class WKTehnologyContext(DbContextOptions<WKTehnologyContext> options) : DbContext(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var assembly = GetType().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
