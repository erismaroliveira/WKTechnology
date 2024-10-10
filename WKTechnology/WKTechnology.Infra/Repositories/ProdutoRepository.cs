using Microsoft.EntityFrameworkCore;
using WKTechnology.Domain.Entities;
using WKTechnology.Infra.Context;
using WKTechnology.Infra.Repositories.Interfaces;

namespace WKTechnology.Infra.Repositories;

public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
{
    private readonly WKTehnologyContext _context;
    
    public ProdutoRepository(WKTehnologyContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> GetAllWithCategoryAsync()
    {
        return await _context.Produtos
            .Include(p => p.Categoria)
            .ToListAsync();
    }

    public async Task<Produto> GetByIdWithCategoryAsync(int id)
    {
        return await _context.Produtos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}