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

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ProdutoDTO produtoDto)
    {
        if (produtoDto == null)
            return BadRequest("Produto não pode ser nulo.");

        var createdProduto = await _produtoService.CreateAsync(produtoDto);
        return Ok(createdProduto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var produtoDto = await _produtoService.GetByIdAsync(id);
        if (produtoDto == null)
            return NotFound();

        return Ok(produtoDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWithCategoryAsync()
    {
        var produtosDto = await _produtoService.GetAllWithCategoryAsync();
        return Ok(produtosDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProdutoDTO produtoDto)
    {
        if (id != produtoDto.Id)
            return BadRequest("Produto não pode ser nulo.");
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = await _produtoService.UpdateAsync(produtoDto);
        if (!isUpdated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var isDeleted = await _produtoService.DeleteAsync(id);
        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
}
