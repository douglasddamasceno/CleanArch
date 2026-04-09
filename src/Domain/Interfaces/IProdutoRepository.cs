using Domain.Entities;

namespace Domain.Interfaces;

public interface IProdutoRepository
{
    Task AddAsync(Produto produto);
    Task<Produto> FindAsync(Guid id);
    Task<IEnumerable<Produto>> FindAllAsync();
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(Produto produto);
}