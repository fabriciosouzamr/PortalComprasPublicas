using System.Net;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;

namespace PortalComprasPublicasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogSecController : ControllerBase
    {

        private readonly ILogSecRepository _LogSecRepository;
        private readonly IMapper _mapper;

        public LogSecController(ILogSecRepository LogSecRepository,
                                 IMapper mapper)
        {
            _LogSecRepository = LogSecRepository;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IEnumerable<LogSecViewModel>> ObterTodos(int offset = 1, int limite = 50)
        //{
        //    return _mapper.Map<IEnumerable<LogSecViewModel>>(await _LogSecRepository.ObterTodos(offset, limite));
        //}
    }
}