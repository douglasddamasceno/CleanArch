using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Produtos;

public class CreateProdutoUseCase
{
    private readonly IProdutoRepository _repository;

    public CreateProdutoUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> ExecuteAsync(CreateProdutoCommand request)
    {
        var produto = new Produto(request.Nome, request.Preco);

        await _repository.AddAsync(produto);
        return Result.Success();
    }
}