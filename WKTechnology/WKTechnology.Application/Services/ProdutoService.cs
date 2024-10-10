using AutoMapper;
using WKTechnology.Application.Services.Interfaces;
using WKTechnology.Domain.Entities;
using WKTechnology.Infra.Repositories.Interfaces;
using WKTechnology.Shared.DTOs;

namespace WKTechnology.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public async Task<ProdutoDTO> CreateAsync(ProdutoDTO produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        var createdProduto = await _produtoRepository.InsertAsync(produto);
        return _mapper.Map<ProdutoDTO>(createdProduto);
    }

    public async Task<ProdutoDTO> GetByIdAsync(int id)
    {
        var produto = await _produtoRepository.FindAsync(c => c.Id == id);
        return _mapper.Map<ProdutoDTO>(produto);
    }

    public async Task<IEnumerable<ProdutoDTO>> GetAllWithCategoryAsync()
    {
        var produtos = await _produtoRepository.GetAllWithCategoryAsync();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
    }

    public async Task<bool> UpdateAsync(ProdutoDTO produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        return await _produtoRepository.UpdateAsync(produto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var produto = await _produtoRepository.FindAsync(c => c.Id == id);
        if (produto == null)
            return false;
        return await _produtoRepository.DeleteAsync(produto);
    }
}
