using Domain.Common;
using Domain.Common.Errors;
using Domain.Interfaces;

namespace Application.Produtos;

public class DeleteProdutoUseCase
{
    private readonly IProdutoRepository _repository;

    public DeleteProdutoUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> ExecuteAsync(Guid id)
    {
        var produto = await _repository.FindAsync(id);
        if (produto is null)
            return Result.Failure(CommonErrors.NotFound);

        await _repository.DeleteAsync(produto);
        return Result.Success();
    }
}