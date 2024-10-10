using WKTechnology.Domain.Entities;

namespace WKTechnology.Shared.ViewModels;

public class ProdutoViewModel
{
    public int Id { get; set; }
    public int CategoriaId { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public bool Ativo { get; set; }
    public DateTime? DataInativacao { get; set; }
    public ValorDescricaoViewModel? Categoria { get; set; }
    
    public ProdutoViewModel(Produto produto)
    {
        Id = produto.Id;
        CategoriaId = produto.CategoriaId;
        Nome = produto.Nome;
        Descricao = produto.Descricao;
        Preco = produto.Preco;
        Ativo = produto.Ativo;
        DataInativacao = produto.DataInativacao;

        Categoria = produto.Categoria != null
            ? new ValorDescricaoViewModel(produto.CategoriaId, produto.Categoria.Nome)
            : null;
    }
}