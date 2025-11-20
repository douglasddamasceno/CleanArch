using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Produtos.CriarProduto;

public class CriarProdutoUseCase
{
    private readonly IProdutoRepository _repository;

    public CriarProdutoUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecutarAsync(CriarProdutoCommand command)
    {
        // 1. Regras de Negócio e Validação (Usando a Entidade do Domain)
        var produto = new Produto(command.Nome, command.Preco);

        // 2. Persistência (Chama a Infraestrutura via Repositório)
        await _repository.AdicionarAsync(produto);
    }
}