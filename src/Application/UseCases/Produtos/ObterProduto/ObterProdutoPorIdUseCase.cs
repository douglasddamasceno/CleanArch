using Application.Interfaces;

namespace Application.UseCases.Produtos.ObterProduto;

public class ObterProdutoPorIdUseCase
{
    private readonly IProdutoRepository _repository;

    public ObterProdutoPorIdUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProdutoResponse> ExecutarAsync(Guid id)
    {
        var produto = await _repository.ObterPorIdAsync(id);
        return new ProdutoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco
        };
    }
}