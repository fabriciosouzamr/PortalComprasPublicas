using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Domain.Service;
using PortalComprasPublicas.Infrastructure.Data;
using PortalComprasPublicas.Infrastructure.Data.Context;
using PortalComprasPublicas.Infrastructure.Data.Repository;

namespace PortalComprasPublicas.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Data
            services.AddScoped<MySqlDbContext>();
            services.AddScoped<SqlLiteDbContext>();
            #endregion

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IRepository<Cliente>, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IRepository<Produto>, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IRepository<Venda>, VendaRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IService<Cliente>, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IService<Produto>, ProdutoService>();

            return services;
        }
    }

    public static class DependencyInjectionConfigConfigAssistant
    {
        public static WebApplicationBuilder AddDependencyInjectionConfig(this WebApplicationBuilder builder)
        {
            builder.Services.ResolveDependencies();

            return builder;
        }
    }
}
