using WKTechnology.Domain.Entities;

namespace WKTechnology.Infra.Repositories.Interfaces;

public interface ICategoriaRepository : IGenericRepository<Categoria>
{
    Task<Categoria> GetByIdWithProductsAsync(int id);
    Task<IEnumerable<Categoria>> GetAllWithProductsAsync();
}