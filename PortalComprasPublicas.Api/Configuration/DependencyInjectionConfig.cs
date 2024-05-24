namespace PortalComprasPublicas.Application.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfig(this WebApplicationBuilder builder)
        {
            builder.Services.ResolveDependencies();

            return builder;
        }
    }
}