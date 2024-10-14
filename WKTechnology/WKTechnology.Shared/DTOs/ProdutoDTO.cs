using Flunt.Notifications;
using Flunt.Validations;
using WKTechnology.Domain.Entities;

namespace WKTechnology.Shared.DTOs;

public class ProdutoDTO : Notifiable
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }
    public string? CategoriaNome { get; set; }

    public ProdutoDTO()
    {
        
    }

    public ProdutoDTO(Produto produto)
    {
        Id = produto.Id;
        Nome = produto.Nome;
        Descricao = produto.Descricao;
        Preco = produto.Preco;
        CategoriaId = produto.CategoriaId;
        CategoriaNome = produto.Categoria?.Nome;
    }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(Nome, "Produto.Nome", "Nome obrigatório")
            .IsGreaterThan(Preco, 0, "Produto.Preco", "O preço deve ser maior que zero")
            .IsGreaterThan(CategoriaId, 0, "Produto.CategoriaId", "A categoria deve ser válida")
        );
    }
}