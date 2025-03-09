using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();

        // Scoped = created once per request
        // Transient = short. Better for serviceless
        // Singleton = 1 instance
        services.AddScoped<ITokenService, TokenService>(); // AddScoped<TokenService>() works too
                                                                   // but this way is better for testing purposes
        return services;    
    }
}
