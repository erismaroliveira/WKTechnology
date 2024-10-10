using AutoMapper;
using WKTechnology.Domain.Entities;
using WKTechnology.Application.Services.Interfaces;
using WKTechnology.Infra.Repositories.Interfaces;
using WKTechnology.Shared.DTOs;

namespace WKTechnology.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
    }

    public async Task<CategoriaDTO> CreateAsync(CategoriaDTO categoriaDto)
    {
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        var createdCategoria = await _categoriaRepository.InsertAsync(categoria);
        return _mapper.Map<CategoriaDTO>(createdCategoria);
    }

    public async Task<CategoriaDTO> GetByIdAsync(int id)
    {
        var categoria = await _categoriaRepository.FindAsync(c => c.Id == id);
        return _mapper.Map<CategoriaDTO>(categoria);
    }

    public async Task<IEnumerable<CategoriaDTO>> GetAllWithProductsAsync()
    {
        var categorias = await _categoriaRepository.GetAllWithProductsAsync();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
    }

    public async Task<bool> UpdateAsync(CategoriaDTO categoriaDto)
    {
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        return await _categoriaRepository.UpdateAsync(categoria);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var categoria = await _categoriaRepository.FindAsync(c => c.Id == id);
        return categoria != null && await _categoriaRepository.DeleteAsync(categoria);
    }
}
