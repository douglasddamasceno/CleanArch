using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Produtos.CriarProduto;

public record CriarProdutoCommand(
    [Required][StringLength(150, MinimumLength = 3)] string Nome,
    [Required][Range(0.01, 999999)][CreditCard] decimal Preco);