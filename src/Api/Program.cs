using Api.Endpoints;
using CleanArch.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.Services.AddSwaggerConfig();
builder.Services.AddHealthChecks();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddDependencyInjectionConfig(builder.Configuration);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseHealthChecks("/health");
app.MapProdutoEndpoints();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.Run();