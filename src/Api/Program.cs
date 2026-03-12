using Api.Endpoints;
using Application.Interfaces;
using Application.Services;
using CleanArch.Api.Config;

//using CleanArch.Api.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddDocsConfig();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LojaConnection")));
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddHealthChecks();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseHealthChecks("/health");
if (app.Environment.IsDevelopment())
{
    app.UseDocsConfig();
}

app.MapProdutoEndpoints();

app.Run();