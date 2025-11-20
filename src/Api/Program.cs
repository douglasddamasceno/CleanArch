using Api.Endpoints;
using Application.Interfaces;
using Application.UseCases.Produtos.CriarProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<CriarProdutoUseCase>();
builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Clean Architecture",
                    Version = "v1.0",
                    Description = "Base arquitetural para aplicações .NET seguindo os princípios da Arquitetura Limpa (Clean Arch).",
                    Contact = new OpenApiContact
                    {
                        Name = "Douglas Damasceno",
                        Email = "douglasddx@gmail.com",
                        Url = new Uri("https://github.com/douglasddamasceno/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                }
            );
        });

var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Arch API v1");
    c.RoutePrefix = string.Empty;
});

app.MapGet("/health", () =>
{
    return DateTime.Now;
})
.WithName("Health");

app.MapProdutoEndpoints();

app.Run();