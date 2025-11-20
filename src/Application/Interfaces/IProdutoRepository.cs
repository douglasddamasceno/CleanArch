// Interfaces/IProdutoRepository.cs (A Porta - Depende de Domain)
using Domain.Entities;

namespace Application.Interfaces;

public interface IProdutoRepository
{
    Task AdicionarAsync(Produto produto);
    // ... Task BuscarPorIdAsync(int id);
}