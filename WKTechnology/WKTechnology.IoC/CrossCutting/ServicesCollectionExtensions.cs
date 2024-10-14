using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WKTechnology.Application.Services;
using WKTechnology.Application.Services.Interfaces;
using WKTechnology.Domain.Entities;
using WKTechnology.Infra.Context;
using WKTechnology.Infra.Repositories;
using WKTechnology.Infra.Repositories.Interfaces;

namespace WKTechnology.IoC.CrossCutting;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IProdutoService, ProdutoService>();

        return services;
    }
    
    public static IServiceCollection AddRepositoriesServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Categoria>, GenericRepository<Categoria>>();
        services.AddScoped<IGenericRepository<Produto>, GenericRepository<Produto>>();

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WKTehnologyContext>(options =>
            options.UseMySql(configuration.GetConnectionString("WKTehnologyConnection"),
                new MySqlServerVersion(new Version(8, 0, 39))));
        
        return services;
    }
}