namespace Application.Services.Models.ProdutoModels;

public class ProdutoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}