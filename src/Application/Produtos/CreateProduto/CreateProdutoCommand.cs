namespace Application.Produtos;

public record CreateProdutoCommand(
    string Nome,
    decimal Preco);