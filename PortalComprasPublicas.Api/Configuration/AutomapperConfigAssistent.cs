using PortalComprasPublicas.Application.Configuration;

namespace PortalComprasPublicas.Api.Configuration
{
    /// <summary>
    /// Classe auxiliar ativação do automapper
    /// </summary>
    public static class AutomapperConfigAssistent
    {
        public static WebApplicationBuilder AddAutoMapperConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AutomapperConfig));

            return builder;
        }
    }
}
