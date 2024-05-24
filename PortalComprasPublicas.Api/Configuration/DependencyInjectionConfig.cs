namespace PortalComprasPublicas.Application.Configuration
{
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Classe auxiliar da injeção de dependência do objetos usados na Api
        /// </summary>
        public static WebApplicationBuilder AddDependencyInjectionConfig(this WebApplicationBuilder builder)
        {
            builder.Services.ResolveDependencies();

            return builder;
        }
    }
}