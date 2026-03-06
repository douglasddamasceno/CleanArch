using Application.Interfaces;

namespace Application.UseCases.Produtos.ObterProduto;

public class ObterTodosProdutosUseCase
{
    private readonly IProdutoRepository _repository;

    public ObterTodosProdutosUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProdutoResponse>> ExecutarAsync()
    {
        var produtos = await _repository.ObterTodosAsync();
        return produtos.Select(p => new ProdutoResponse
        {
            Id = p.Id,
            Nome = p.Nome,
            Preco = p.Preco
        });
    }
}