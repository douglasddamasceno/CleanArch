using Api.Contracts;
using Api.Extensions;
using Api.Mappers;
using Application.Produtos;
using Domain.Common;
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
            .Produces<ProdutoResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        group.MapGet("/", ObterProdutos)
            .WithName("ObterProdutos")
            .Produces<IEnumerable<ProdutoResponse>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        group.MapGet("/{id:guid}", ObterProdutoPorId)
            .WithName("ObterProduto")
            .Produces<ProdutoResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        group.MapPut("/{id:guid}", AtualizarProduto)
            .WithName("AtualizarProduto")
            .Produces<ProdutoResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        group.MapDelete("/{id:guid}", ExcluirProduto)
            .WithName("ExcluirProduto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> CriarProduto(
    [FromBody] CriarProdutoRequest request,
    [FromServices] CreateProdutoUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(request.ToCommand());
        return result.ToResult();
    }

    private static async Task<IResult> ObterProdutos(
    [FromServices] GetAllProdutosUseCase useCase)
    {
        var result = await useCase.ExecuteAsync();
        return result.ToResult();
    }

    private static async Task<IResult> ObterProdutoPorId(
    [FromRoute, Required] Guid id,
    [FromServices] GetByIdProdutoUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(id);
        return result.ToResult();
    }

    private static async Task<IResult> AtualizarProduto(
    [FromRoute, Required] Guid id,
    [FromBody] AtualizarProdutoRequest request,
    [FromServices] UpdateProdutoUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(id, request.ToCommand());
        return result.ToResult();
    }

    private static async Task<IResult> ExcluirProduto(
    [FromRoute, Required] Guid id,
    [FromServices] DeleteProdutoUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(id);
        return result.ToResult();
    }
}