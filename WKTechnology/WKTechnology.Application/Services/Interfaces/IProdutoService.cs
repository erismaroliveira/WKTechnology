using WKTechnology.Domain.Entities;
using WKTechnology.Shared.DTOs;

namespace WKTechnology.Application.Services.Interfaces;

public interface IProdutoService
{
    Task<ProdutoDTO> CreateAsync(ProdutoDTO produtoDto);
    Task<ProdutoDTO> GetByIdAsync(int id);
    Task<IEnumerable<ProdutoDTO>> GetAllWithCategoryAsync();
    Task<bool> UpdateAsync(ProdutoDTO produtoDto);
    Task<bool> DeleteAsync(int id);
}
