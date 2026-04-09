namespace Application.Produtos;

public record UpdateProdutoCommand(
    Guid Id,
    string Nome,
    decimal Preco);