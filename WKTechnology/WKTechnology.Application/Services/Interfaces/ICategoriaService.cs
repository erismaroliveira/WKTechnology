using WKTechnology.Shared.DTOs;
using WKTechnology.Shared.Models;

namespace WKTechnology.Application.Services.Interfaces;

public interface ICategoriaService
{
    Task<ResponseModel<CategoriaDTO>> CreateAsync(CategoriaDTO categoriaDto);
    Task<CategoriaDTO> GetByIdAsync(int id);
    Task<IEnumerable<CategoriaDTO>> GetAllWithProductsAsync();
    Task<ResponseModel<bool>> UpdateAsync(CategoriaDTO categoriaDto);
    Task<bool> DeleteAsync(int id);
    Task<bool> InactivateAsync(int id);
}