using Api.Endpoints;
using Application.Interfaces;
using Application.UseCases.Produtos.AtualizarProduto;
using Application.UseCases.Produtos.CriarProduto;
using Application.UseCases.Produtos.ExcluirProduto;
using Application.UseCases.Produtos.ObterProduto;
using CleanArch.Api.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LojaConnection")));
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<CriarProdutoUseCase>();
builder.Services.AddScoped<ObterTodosProdutosUseCase>();
builder.Services.AddScoped<ObterProdutoPorIdUseCase>();
builder.Services.AddScoped<AtualizarProdutoUseCase>();
builder.Services.AddScoped<ExcluirProdutoUseCase>();
builder.Services.AddSwagger();
builder.Services.AddHealthChecks();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseHealthChecks("/health");

app.MapProdutoEndpoints();

app.Run();