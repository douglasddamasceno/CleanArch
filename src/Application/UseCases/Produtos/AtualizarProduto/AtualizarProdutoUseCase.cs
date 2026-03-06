using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.Produtos.AtualizarProduto;

public class AtualizarProdutoUseCase
{
    private readonly IProdutoRepository _repository;

    public AtualizarProdutoUseCase(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecutarAsync(Guid id, AtualizarProdutoRequest request)
    {
        // 1. Obter Produto Existente e Atualizar com as regras de negócio
        var produtoExistente = await _repository.ObterPorIdAsync(id);
        produtoExistente.Atualizar(request.Nome, request.Preco);

        // 2. Persistência (Chama a Infraestrutura via Repositório)
        await _repository.AtualizarAsync(produtoExistente);
    }
}