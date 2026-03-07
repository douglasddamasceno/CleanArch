using Application.Services;
using Application.Services.Contracts.ProdutoContratcs;
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

        group.MapPut("/{id:guid}", AtualizarProduto)
            .WithName("AtualizarProduto")
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        group.MapDelete("/{id:guid}", ExcluirProduto)
            .WithName("ExcluirProduto")
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> CriarProduto(
    [FromBody] CriarProdutoRequest request,
    [FromServices] ProdutoService service)
    {
        await service.CreateAsync(request);
        return TypedResults.Created();
    }

    private static async Task<IResult> ObterProdutos(
    [FromServices] ProdutoService service)
    {
        var produtos = await service.GetAllAsync();
        if (!produtos.Any() || produtos is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(produtos);
    }

    private static async Task<IResult> ObterProdutoPorId(
    [FromRoute, Required] Guid id,
    [FromServices] ProdutoService service)
    {
        var produto = await service.GetByIdAsync(id);
        return produto is not null ? TypedResults.Ok(produto) : TypedResults.NotFound();
    }

    private static async Task<IResult> AtualizarProduto(
    [FromRoute, Required] Guid id,
    [FromBody] AtualizarProdutoRequest request,
    [FromServices] ProdutoService service)
    {
        await service.UpdateAsync(id, request);
        return TypedResults.Ok();
    }

    private static async Task<IResult> ExcluirProduto(
    [FromRoute, Required] Guid id,
    [FromServices] ProdutoService service)
    {
        await service.DeleteAsync(id);
        return TypedResults.Ok();
    }
}