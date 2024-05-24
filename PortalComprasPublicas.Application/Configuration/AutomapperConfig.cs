using AutoMapper;
using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Application.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<LogSec, LogSecViewModel>().ReverseMap();
        }
    }
}
