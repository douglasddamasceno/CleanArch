using Application.Interfaces;

namespace Application.UseCases.Produtos.ExcluirProduto;

public class ExcluirProdutoUseCase
{
    private readonly IProdutoRepository _repository;

    public ExcluirProdutoUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecutarAsync(Guid id)
    {
        var produto = await _repository.ObterPorIdAsync(id);
        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }

        await _repository.RemoverAsync(id);
    }
}