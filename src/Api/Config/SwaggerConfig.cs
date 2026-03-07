using Microsoft.OpenApi.Models;

namespace CleanArch.Api.Config;

public static class SwaggerConfig
{
    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
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
    }

    public static void UseSwaggerConfig(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Arch API v1");
            c.RoutePrefix = string.Empty;
        });
    }
}