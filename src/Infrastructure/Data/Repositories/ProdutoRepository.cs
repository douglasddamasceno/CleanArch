using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
    }

    public async Task<Produto> ObterPorIdAsync(Guid guid)
    {
        return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == guid);
    }

    public async Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }
}