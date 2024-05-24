using AutoMapper;
using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Application.Configuration
{
    /// <summary>
    /// Classe responsavel por mapeamento dos objetos
    /// </summary>
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
