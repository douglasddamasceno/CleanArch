using System.ComponentModel.DataAnnotations;

namespace Api.Contracts;

public record AtualizarProdutoRequest(
    [Required] Guid Id,
    [Required][StringLength(150, MinimumLength = 3)] string Nome,
    [Required][Range(0.01, 999999)] decimal Preco);