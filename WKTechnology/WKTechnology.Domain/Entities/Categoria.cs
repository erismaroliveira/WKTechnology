namespace WKTechnology.Domain.Entities;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; private set; } = string.Empty;
    public bool Ativo { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public DateTime? DataInativacao { get; private set; }
    public virtual ICollection<Produto> Produtos { get; set; }

    public Categoria()
    {
        Produtos = new List<Produto>();
        Ativo = true;
        DataCadastro = DateTime.Now;
    }

    public Categoria(string nome, bool ativo)
    {
        Nome = nome;
        Ativo = ativo;
        DataCadastro = DateTime.Now;
    }

    public void Atualizar(string nome, bool ativo)
    {
        Nome = nome;
        Ativo = ativo;
    }

    public void Inativar()
    {
        Ativo = false;
        DataInativacao = DateTime.Now;
    }
}

