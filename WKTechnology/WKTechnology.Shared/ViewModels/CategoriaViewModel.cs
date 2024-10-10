using WKTechnology.Domain.Entities;

namespace WKTechnology.Shared.ViewModels;

public class CategoriaViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<ProdutoViewModel> Produtos { get; set; } = new List<ProdutoViewModel>();

    public CategoriaViewModel(Categoria categoria)
    {
        Id = categoria.Id;
        Nome = categoria.Nome;

        // Converte os produtos para o ViewModel correspondente
        Produtos = categoria.Produtos.Select(p => new ProdutoViewModel(p)).ToList();
    }
}
