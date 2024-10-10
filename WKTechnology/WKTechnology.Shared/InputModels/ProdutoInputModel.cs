using Flunt.Notifications;
using Flunt.Validations;

namespace WKTechnology.Shared.InputModels;

public class ProdutoInputModel : Notifiable
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; } = 0.00m;
    public bool Ativo { get; set; }
    public int CategoriaId { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataInativacao { get; set; }

    public ProdutoInputModel()
    { }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotNull(Nome, "Produto.Nome", "Nome obrigatório")
        );
    }
}