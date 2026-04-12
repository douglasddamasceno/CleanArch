using Domain.Common;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Produtos;

public class GetAllProdutosHandler
{
    private readonly IProdutoRepository _repository;

    public GetAllProdutosHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<Produto>>> ExecuteAsync()
    {
        var produtos = await _repository.FindAllAsync();

        if (produtos is null || !produtos.Any())
            return Result<IEnumerable<Produto>>.Failure(CommonErrors.NotFound);

        return Result<IEnumerable<Produto>>.Success(produtos);
    }
}