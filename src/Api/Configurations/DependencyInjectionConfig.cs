using Application.Produtos;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Api.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LojaConnection")));

        services.AddScoped<IProdutoRepository, ProdutoRepository>();

        services.AddScoped<CreateProdutoHandler>();
        services.AddScoped<GetAllProdutosHandler>();
        services.AddScoped<GetByIdProdutoHandler>();
        services.AddScoped<UpdateProdutoHandler>();
        services.AddScoped<DeleteProdutoHandler>();
    }
}