using Microsoft.EntityFrameworkCore;
using WKTechnology.Application.Services.Interfaces;
using WKTechnology.Domain.Entities;
using WKTechnology.Infra.Repositories.Interfaces;
using WKTechnology.Shared.DTOs;
using WKTechnology.Shared.Models;

namespace WKTechnology.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IGenericRepository<Produto> _produtoRepository;

    public ProdutoService(IGenericRepository<Produto> produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResponseModel<ProdutoDTO>> CreateAsync(ProdutoDTO produtoDto)
    {
        produtoDto.Validate();

        if (produtoDto.Invalid)
        {
            return new ResponseModel<ProdutoDTO>(null, produtoDto.Notifications);
        }

        var produto = new Produto(
            produtoDto.Nome,
            produtoDto.Descricao,
            produtoDto.Preco,
            true,
            produtoDto.CategoriaId);

        try
        {
            var resultado = await _produtoRepository.InsertAsync(produto).ConfigureAwait(false);

            if (resultado is null)
            {
                produtoDto.AddNotification("Produto.Cadastro", "Houve um erro inesperado ao cadastrar produto");
                return new ResponseModel<ProdutoDTO>(null, produtoDto.Notifications);
            }

            var produtoCriadoDto = new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = produto.Categoria?.Nome
            };

            return new ResponseModel<ProdutoDTO>(produtoCriadoDto);
        }
        catch (Exception ex)
        {
            produtoDto.AddNotification("Produto.Cadastro", $"Erro ao cadastrar produto: {ex.Message}");
            return new ResponseModel<ProdutoDTO>(null, produtoDto.Notifications);
        }
    }

    public async Task<ProdutoDTO> GetByIdAsync(int id)
    {
        var produto = _produtoRepository.Find(p => p.Id == id, p => p.Categoria);
        if (produto is null)
        {
            return null;
        }
        return new ProdutoDTO(produto);
    }

    public async Task<IEnumerable<ProdutoDTO>> GetAllWithCategoryAsync()
    {
        var produtos = await _produtoRepository.FindAll(p => p.Ativo == true, q => q.Include(p => p.Categoria)).ToListAsync();
        
        var produtoDTOs = produtos.Select(p => new ProdutoDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Preco = p.Preco,
            CategoriaId = p.CategoriaId,
            CategoriaNome = p.Categoria?.Nome
        });

        return produtoDTOs;
    }

    public async Task<ResponseModel<bool>> UpdateAsync(ProdutoDTO produtoDto)
    {
        produtoDto.Validate();

        if (produtoDto.Invalid)
        {
            return new ResponseModel<bool>(false, produtoDto.Notifications);
        }

        var produto = await _produtoRepository.FindAsync(c => c.Id == produtoDto.Id);

        if (produto is null)
        {
            produtoDto.AddNotification("Produto.Atualizar", "Produto não encontrado");
            return new ResponseModel<bool>(false, produtoDto.Notifications);
        }

        produto.Atualizar(
            produtoDto.Nome,
            produtoDto.Descricao,
            produtoDto.Preco,
            true,
            produtoDto.CategoriaId);

        var resultado = await _produtoRepository.UpdateAsync(produto).ConfigureAwait(false);

        if (!resultado)
        {
            produtoDto.AddNotification("Produto.Atualizacao", "Houve um erro inesperado ao atualizar produto");

            return new ResponseModel<bool>(false, produtoDto.Notifications);
        }

        return new ResponseModel<bool>(resultado);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var produto = await _produtoRepository.FindAsync(c => c.Id == id);

            if (produto is null)
                return false;

            return await _produtoRepository.DeleteAsync(produto);
        }
        catch (Exception)
        {
            return false;
        }
    }
}
