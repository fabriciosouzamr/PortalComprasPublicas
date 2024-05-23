using AutoMapper;
using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Entities;

namespace PortalComprasPublicas.Api.Configuration
{
    public static class AutoMapperConfigAssistant
    {
        public static WebApplicationBuilder AddAutoMapperConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return builder;
        }
    }

    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
            CreateMap<VendaItem, VendaItemViewModel>().ReverseMap();
        }
    }
}
