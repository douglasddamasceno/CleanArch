using Api.Endpoints;
using CleanArch.Api.Config;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.Services.AddSwaggerConfig();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LojaConnection")));
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddHealthChecks();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseHealthChecks("/health");
app.MapProdutoEndpoints();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.Run();