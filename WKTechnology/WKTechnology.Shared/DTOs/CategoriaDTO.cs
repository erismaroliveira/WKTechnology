using Flunt.Notifications;
using Flunt.Validations;
using WKTechnology.Domain.Entities;

namespace WKTechnology.Shared.DTOs;

public class CategoriaDTO : Notifiable
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }
    public List<ProdutoDTO> Produtos { get; set; } = [];

    public CategoriaDTO()
    {
        
    }

    public CategoriaDTO(Categoria categoria)
    {
        Id = categoria.Id;
        Nome = categoria.Nome;
        Ativo = categoria.Ativo;
        Produtos = categoria.Produtos.Select(c => new ProdutoDTO(c)).ToList();
    }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(Nome, "Categoria.Nome", "Nome obrigatório")
        );
    }
}