using System.Security.AccessControl;
using Domain.Common;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Produtos;

public class UpdateProdutoUseCase
{
    private readonly IProdutoRepository _repository;

    public UpdateProdutoUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Produto>> ExecuteAsync(Guid id, UpdateProdutoCommand command)
    {
        if (id == command.Id)
            return Result<Produto>.Failure(CommonErrors.Conflict);

        var produto = await _repository.FindAsync(id);
        if (produto is null)
            return Result<Produto>.Failure(CommonErrors.NotFound);

        produto.Atualizar(command.Nome, command.Preco);
        await _repository.UpdateAsync(produto);

        return Result<Produto>.Success(produto);
    }
}