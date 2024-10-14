using Microsoft.EntityFrameworkCore;
using WKTechnology.Domain.Entities;
using WKTechnology.Infra.Context;
using WKTechnology.Infra.Repositories.Interfaces;

namespace WKTechnology.Infra.Repositories;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
{
    private readonly WKTehnologyContext _context;
    
    public CategoriaRepository(WKTehnologyContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Categoria> GetByIdWithProductsAsync(int id)
    {
        return await _context.Categorias
            .Include(c => c.Produtos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Categoria>> GetAllWithProductsAsync()
    {
        return await _context.Categorias
            .Include(c => c.Produtos)
            .ToListAsync();
    }
}