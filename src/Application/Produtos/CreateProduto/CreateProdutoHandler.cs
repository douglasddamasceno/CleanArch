using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Produtos;

public class CreateProdutoHandler
{
    private readonly IProdutoRepository _repository;

    public CreateProdutoHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Produto>> ExecuteAsync(CreateProdutoCommand request)
    {
        var produto = new Produto(request.Nome, request.Preco);

        await _repository.AddAsync(produto);
        return Result<Produto>.Success(produto);
    }
}