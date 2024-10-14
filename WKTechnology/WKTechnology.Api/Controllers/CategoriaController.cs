using Microsoft.AspNetCore.Mvc;
using WKTechnology.Application.Services.Interfaces;
using WKTechnology.Shared.DTOs;

namespace WKTechnology.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet("obter-todas")]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _categoriaService.GetAllWithProductsAsync();
        return Ok(categorias);
    }

    [HttpGet("obter-por-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);

        if (categoria is null)
        {
            return NotFound(new { message = "Categoria não encontrada." });
        }

        return Ok(categoria);
    }

    [HttpPost("criar")]
    public async Task<IActionResult> Create([FromBody] CategoriaDTO categoriaDto)
    {
        var createdCategoria = await _categoriaService.CreateAsync(categoriaDto);
        return Ok(createdCategoria);
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Update([FromBody] CategoriaDTO categoriaDto)
    {
        var isUpdated = await _categoriaService.UpdateAsync(categoriaDto);
        return Ok(isUpdated);
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _categoriaService.DeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound(new { message = "Categoria não encontrada ou não pôde ser excluída." });
        }

        return NoContent();
    }

    [HttpPatch("inativar/{id}")]
    public async Task<IActionResult> Inactivate(int id)
    {
        var isInactivated = await _categoriaService.InactivateAsync(id);

        if (!isInactivated)
        {
            return NotFound(new { message = "Categoria não encontrada." });
        }

        return NoContent();
    }
}
