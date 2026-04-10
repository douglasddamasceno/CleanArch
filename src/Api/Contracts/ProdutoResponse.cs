namespace Api.Contracts;

public record ProdutoResponse(
    Guid Id,
    string Nome,
    decimal Preco);