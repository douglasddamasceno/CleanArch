using Application.UseCases.Produtos.CriarProduto;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Endpoints;

public static class ProdutoEndpoints
{
    public static void MapProdutoEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1/produtos")
        .WithTags("Produtos");

        group.MapPost("/criar", CriarProduto)
            .WithName("CriarProduto")
            .Produces<string>(StatusCodes.Status201Created)
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
}