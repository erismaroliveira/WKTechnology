namespace WKTechnology.Shared.ViewModels;

public class ValorDescricaoViewModel
{
    public int Valor { get; set; }
    public string Descricao { get; set; }

    public ValorDescricaoViewModel() { }

    public ValorDescricaoViewModel(int valor, string descricao)
    {
        Valor = valor;
        Descricao = descricao;
    }
}