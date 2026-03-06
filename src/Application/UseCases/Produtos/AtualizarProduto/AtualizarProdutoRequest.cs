using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Produtos.AtualizarProduto;

public record AtualizarProdutoRequest(
    [Required] Guid Id,
    [Required][StringLength(150, MinimumLength = 3)] string Nome,
    [Required][Range(0.01, 999999)] decimal Preco);