using Microsoft.AspNetCore.Mvc;
using WKTechnology.Application.Services.Interfaces;
using WKTechnology.Shared.DTOs;

namespace WKTechnology.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet("obter-todos")]
    public async Task<IActionResult> GetAllWithCategoryAsync()
    {
        var produtosDto = await _produtoService.GetAllWithCategoryAsync();
        return Ok(produtosDto);
    }

    [HttpGet("obter-por-id/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var produtoDto = await _produtoService.GetByIdAsync(id);
        return Ok(produtoDto);
    }

    [HttpPost("criar")]
    public async Task<IActionResult> CreateAsync([FromBody] ProdutoDTO produtoDto)
    {
        var createdProduto = await _produtoService.CreateAsync(produtoDto);
        return Ok(createdProduto);
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> UpdateAsync([FromBody] ProdutoDTO produtoDto)
    {
        var isUpdated = await _produtoService.UpdateAsync(produtoDto);
        return Ok(isUpdated);
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var isDeleted = await _produtoService.DeleteAsync(id);
        return Ok(isDeleted);
    }
}
