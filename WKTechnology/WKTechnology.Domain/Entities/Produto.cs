using System.Text.Json.Serialization;

namespace WKTechnology.Domain.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; private set; } = string.Empty;
    public string? Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public DateTime? DataInativacao { get; private set; }
    public int CategoriaId { get; private set; }
    
    [JsonIgnore]
    public virtual Categoria? Categoria { get; set; }

    public Produto()
    { }

    public Produto(string nome, string? descricao, decimal preco, bool ativo, int categoriaId)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Ativo = ativo;
        CategoriaId = categoriaId;
        DataCadastro = DateTime.Now;
    }
    
    public void Atualizar(string nome, string? descricao, decimal preco, bool ativo, int categoriaId)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Ativo = ativo;
        CategoriaId = categoriaId;
    }

    public void Inativar()
    {
        Ativo = false;
        DataInativacao = DateTime.Now;
    }
}
