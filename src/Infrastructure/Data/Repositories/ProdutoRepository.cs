using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
    }

    public async Task<Produto> FindAsync(Guid guid)
    {
        return await _context.Produtos.FirstAsync(p => p.Id == guid);
    }

    public async Task<IEnumerable<Produto>> FindAllAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task UpdateAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Produto produto)
    {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }
}