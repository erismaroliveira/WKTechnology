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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _categoriaService.GetAllWithProductsAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoriaDTO categoriaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdCategoria = await _categoriaService.CreateAsync(categoriaDto);
        return CreatedAtAction(nameof(GetById), new { id = createdCategoria.Id }, createdCategoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoriaDTO categoriaDto)
    {
        if (id != categoriaDto.Id)
        {
            return BadRequest("Incompatibilidade de ID");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = await _categoriaService.UpdateAsync(categoriaDto);
        if (!isUpdated)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao atualizar a categoria");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _categoriaService.DeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
