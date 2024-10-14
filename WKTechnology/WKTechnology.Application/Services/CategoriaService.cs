using Microsoft.EntityFrameworkCore;
using WKTechnology.Application.Services.Interfaces;
using WKTechnology.Domain.Entities;
using WKTechnology.Infra.Repositories.Interfaces;
using WKTechnology.Shared.DTOs;
using WKTechnology.Shared.Models;

namespace WKTechnology.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<ResponseModel<CategoriaDTO>> CreateAsync(CategoriaDTO categoriaDto)
    {
        categoriaDto.Validate();

        if (categoriaDto.Invalid)
        {
            return new ResponseModel<CategoriaDTO>(null, categoriaDto.Notifications);
        }

        var categoria = new Categoria(
            categoriaDto.Nome,
            true);

        try
        {
            var resultado = await _categoriaRepository.InsertAsync(categoria).ConfigureAwait(false);

            if (resultado is null)
            {
                categoriaDto.AddNotification("Categoria.Cadastro", "Houve um erro inesperado ao cadastrar categoria");
                return new ResponseModel<CategoriaDTO>(null, categoriaDto.Notifications);
            }

            var categoriaCriadaDto = new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };

            return new ResponseModel<CategoriaDTO>(categoriaCriadaDto);
        }
        catch (Exception ex)
        {
            categoriaDto.AddNotification("Categoria.Cadastro", $"Erro ao cadastrar categoria: {ex.Message}");
            return new ResponseModel<CategoriaDTO>(null, categoriaDto.Notifications);
        }
    }

    public async Task<CategoriaDTO> GetByIdAsync(int id)
    {
        var categoria = _categoriaRepository.Find(c => c.Id == id, c => c.Produtos);
        if (categoria is null)
        {
            return null;
        }
        return new CategoriaDTO(categoria);
    }

    public async Task<IEnumerable<CategoriaDTO>> GetAllWithProductsAsync()
   {
        var categorias = await _categoriaRepository.FindAll(c => c.Ativo == true, q => q.Include(c => c.Produtos)).ToListAsync();

        var categoriaDTOs = categorias.Select(c => new CategoriaDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Ativo = c.Ativo,
            Produtos = c.Produtos.Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                CategoriaId = p.CategoriaId
            }).ToList()
        });

        return categoriaDTOs;
    }

    public async Task<ResponseModel<bool>> UpdateAsync(CategoriaDTO categoriaDto)
    {
        categoriaDto.Validate();

        if (categoriaDto.Invalid)
        {
            return new ResponseModel<bool>(false, categoriaDto.Notifications);
        }

        var categoria = await _categoriaRepository.FindAsync(c => c.Id == categoriaDto.Id);

        if (categoria is null)
        {
            categoriaDto.AddNotification("Categoria.Atualizar", "Categoria não encontrada");
            return new ResponseModel<bool>(false, categoriaDto.Notifications);
        }

        categoria.Atualizar(
            categoriaDto.Nome,
            true);

        var resultado = await _categoriaRepository.UpdateAsync(categoria).ConfigureAwait(false);

        if (!resultado)
        {
            categoriaDto.AddNotification("Categoria.Atualizacao", "Houve um erro inesperado ao atualizar categoria");

            return new ResponseModel<bool>(false, categoriaDto.Notifications);
        }

        return new ResponseModel<bool>(resultado);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var categoria = await _categoriaRepository.FindAsync(c => c.Id == id);

            if (categoria is null)
            {
                return false;
            }

            return await _categoriaRepository.DeleteAsync(categoria);
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> InactivateAsync(int id)
    {
        var categoria = await _categoriaRepository.FindAsync(c => c.Id == id);

        if (categoria is null)
        {
            return false;
        }

        categoria.Inativar();

        return await _categoriaRepository.UpdateAsync(categoria);
    }
}
