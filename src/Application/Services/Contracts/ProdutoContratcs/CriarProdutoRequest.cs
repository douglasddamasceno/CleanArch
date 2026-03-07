using System.ComponentModel.DataAnnotations;

namespace Application.Services.Contracts.ProdutoContratcs;

public record CriarProdutoRequest(
    [Required][StringLength(150, MinimumLength = 3)] string Nome,
    [Required][Range(0.01, 999999)] decimal Preco);