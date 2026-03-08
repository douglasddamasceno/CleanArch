using System.ComponentModel.DataAnnotations;

namespace Application.Services.Models.ProdutoModels;

public record CriarProdutoRequest(
    [Required][StringLength(150, MinimumLength = 3)] string Nome,
    [Required][Range(0.01, 999999)] decimal Preco);