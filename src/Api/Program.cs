using Application.Interfaces;
using Application.UseCases.Produtos.CriarProduto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<CriarProdutoUseCase>();

var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/health", () =>
{
    return DateTime.Now;
})
.WithName("Health");

app.Run();