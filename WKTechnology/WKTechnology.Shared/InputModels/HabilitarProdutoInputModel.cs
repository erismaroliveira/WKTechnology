namespace WKTechnology.Shared.InputModels;

public class HabilitarProdutoInputModel
{
    public int CategoriaId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public HabilitarProdutoInputModel(int categoriaId, string nome, decimal preco)
    {
        CategoriaId = categoriaId;
        Nome = nome;
        Preco = preco;
    }

    // TODO: validations
}