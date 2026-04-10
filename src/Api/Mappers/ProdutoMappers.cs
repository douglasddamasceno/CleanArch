using Api.Contracts;
using Application.Produtos;
using Domain.Entities;

namespace Api.Mappers;

public static class ProdutoMapper
{
    public static CreateProdutoCommand ToCommand(this CriarProdutoRequest request)
        => new(request.Nome, request.Preco);

    public static UpdateProdutoCommand ToCommand(this AtualizarProdutoRequest request)
        => new(request.Id, request.Nome, request.Preco);

    public static ProdutoResponse ToResponse(this Produto produto)
        => new(produto.Id, produto.Nome, produto.Preco);

    public static IEnumerable<ProdutoResponse> ToResponse(this IEnumerable<Produto> produtos)
        => produtos.Select(p => p.ToResponse());
}