using Domain.Common;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Produtos;

public class GetByIdProdutoHandler
{
    private readonly IProdutoRepository _repository;

    public GetByIdProdutoHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Produto>> ExecuteAsync(Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString()))
            return Result<Produto>.Failure(CommonErrors.Validation);

        var produto = await _repository.FindAsync(id);
        if (produto is null)
            return Result<Produto>.Failure(CommonErrors.NotFound);

        return Result<Produto>.Success(produto);
    }
}