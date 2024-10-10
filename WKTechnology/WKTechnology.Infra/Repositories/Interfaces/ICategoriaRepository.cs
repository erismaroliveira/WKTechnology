using WKTechnology.Domain.Entities;

namespace WKTechnology.Infra.Repositories.Interfaces;

public interface ICategoriaRepository : IGenericRepository<Categoria>
{
    Task<IEnumerable<Categoria>> GetAllWithProductsAsync();
}