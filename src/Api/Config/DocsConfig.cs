using Microsoft.OpenApi;
using Scalar.AspNetCore;

namespace CleanArch.Api.Config;

public static class DocsConfig
{
    public static void AddDocsConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Info = new OpenApiInfo
                {
                    Title = "API de Pedidos",
                    Description = "Endpoints para gestão de pedidos.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Douglas Damasceno",
                        Email = "douglasddx@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                };

                return Task.CompletedTask;
            });
        });
    }

    public static void UseDocsConfig(this WebApplication app)
    {
        app.MapOpenApi("/openapi/v1.json");

        app.MapScalarApiReference("/docs", options =>
        {
            options.WithTitle("API de Pedidos");
        });
    }
}