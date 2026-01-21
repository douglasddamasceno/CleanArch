using Application.UseCases.Produtos.CriarProduto;
using Application.UseCases.Produtos.ObterProduto;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Endpoints;

public static class ProdutoEndpoints
{
    public static void MapProdutoEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1/produtos")
        .WithTags("Produtos");

        group.MapPost("/", CriarProduto)
            .WithName("CriarProduto")
            .Produces<string>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        group.MapGet("/", ObterProdutos)
            .WithName("ObterProdutos")
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        group.MapGet("/{id:guid}", ObterProdutoPorId)
            .WithName("ObterProduto")
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> CriarProduto(
    [FromBody] CriarProdutoCommand command,
    [FromServices] CriarProdutoUseCase useCase)
    {
        await useCase.ExecutarAsync(command);
        return TypedResults.Created();
    }

    private static async Task<IResult> ObterProdutos(
    [FromServices] ObterTodosProdutosUseCase useCase)
    {
        var produtos = await useCase.ExecutarAsync();
        return produtos is not null ? TypedResults.Ok(produtos) : TypedResults.NotFound();
    }

    private static async Task<IResult> ObterProdutoPorId(
    [FromRoute, Required] Guid id,
    [FromServices] ObterProdutoPorIdUseCase useCase)
    {
        var produto = await useCase.ExecutarAsync(id);
        return produto is not null ? TypedResults.Ok(produto) : TypedResults.NotFound();
    }
}