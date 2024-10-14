using WKTechnology.Shared.DTOs;
using WKTechnology.Shared.Models;

namespace WKTechnology.Application.Services.Interfaces;

public interface IProdutoService
{
    Task<ResponseModel<ProdutoDTO>> CreateAsync(ProdutoDTO produtoDto);
    Task<ProdutoDTO> GetByIdAsync(int id);
    Task<IEnumerable<ProdutoDTO>> GetAllWithCategoryAsync();
    Task<ResponseModel<bool>> UpdateAsync(ProdutoDTO produtoDto);
    Task<bool> DeleteAsync(int id);
}
