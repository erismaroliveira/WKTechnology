using WKTechnology.Shared.DTOs;

namespace WKTechnology.Application.Services.Interfaces;

public interface ICategoriaService
{
    Task<CategoriaDTO> CreateAsync(CategoriaDTO categoriaDto);
    Task<CategoriaDTO> GetByIdAsync(int id);
    Task<IEnumerable<CategoriaDTO>> GetAllWithProductsAsync();
    Task<bool> UpdateAsync(CategoriaDTO categoriaDto);
    Task<bool> DeleteAsync(int id);
}