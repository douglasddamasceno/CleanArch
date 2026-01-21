using Application.Interfaces;

namespace Application.UseCases.Produtos.ObterProduto;

public class ObterProdutoPorIdUseCase
{
    private readonly IProdutoRepository _repository;

    public ObterProdutoPorIdUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Produto> ExecutarAsync(Guid id)
    {
        var produto = await _repository.ObterPorIdAsync(id);
        return produto;
    }
}