using PortalComprasPublicas.Application.Configuration;

namespace PortalComprasPublicas.Api.Configuration
{
    public static class AutomapperConfigAssistent
    {
        public static WebApplicationBuilder AddAutoMapperConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AutomapperConfig));

            return builder;
        }
    }
}
