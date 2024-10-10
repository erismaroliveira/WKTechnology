using Flunt.Notifications;
using Flunt.Validations;

namespace WKTechnology.Shared.InputModels;

public class CategoriaInputModel : Notifiable
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataInativacao { get; set; }
    public List<ProdutoInputModel> Produtos { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .IsNotNull(Nome, "Categoria.Nome", "Nome obrigatório")
        );
    }
}