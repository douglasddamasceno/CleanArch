using Application.Interfaces;
using Application.Services.Contracts.ProdutoContratcs;
using Domain.Entities;

namespace Application.Services;

public class ProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CriarProdutoRequest request)
    {
        // 1. Regras de Negócio e Validação (Usando a Entidade do Domain)
        var produto = new Produto(request.Nome, request.Preco);

        // 2. Persistência (Chama a Infraestrutura via Repositório)
        await _repository.AdicionarAsync(produto);
    }

    public async Task UpdateAsync(Guid id, AtualizarProdutoRequest request)
    {
        // 1. Obter Produto Existente e Atualizar com as regras de negócio
        var produtoExistente = await _repository.ObterPorIdAsync(id);
        produtoExistente.Atualizar(request.Nome, request.Preco);

        // 2. Persistência (Chama a Infraestrutura via Repositório)
        await _repository.AtualizarAsync(produtoExistente);
    }

    public async Task DeleteAsync(Guid id)
    {
        var produto = await _repository.ObterPorIdAsync(id);
        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }

        await _repository.RemoverAsync(id);
    }

    public async Task<ProdutoResponse> GetByIdAsync(Guid id)
    {
        var produto = await _repository.ObterPorIdAsync(id);
        return new ProdutoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco
        };
    }

    public async Task<IEnumerable<ProdutoResponse>> GetAllAsync()
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