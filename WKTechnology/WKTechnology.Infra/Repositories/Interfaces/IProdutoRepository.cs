using WKTechnology.Domain.Entities;

namespace WKTechnology.Infra.Repositories.Interfaces;

public interface IProdutoRepository : IGenericRepository<Produto>
{
    Task<IEnumerable<Produto>> GetAllWithCategoryAsync();
    Task<Produto> GetByIdWithCategoryAsync(int id);
}