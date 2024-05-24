using System.Net;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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

        /// <summary>
        /// Retorna data e hora atual
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>Data e hora</returns>
        /// <response code="200">Retorna a data e hora atual</response>       
        [HttpGet("Agora")]
        public IActionResult Agora()
        {
            var agora = DateTime.Now;
            return Ok(new { Time = agora });
        }

        /// <summary>
        /// Lista os losgs paginados, cada pagina tem no maximo 50 registros
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>os produtos paginados</returns>
        /// <response code="200">Retorna os logs cadastros paginados</response>       
        /// <response code="204">Retorna caso não encontre logs cadastrados</response>

        [HttpGet]
        [ProducesResponseType((StatusCodes.Status200OK), Type = typeof(List<dynamic>))]
        [ProducesResponseType((StatusCodes.Status404NotFound))]
        public async Task<ActionResult> ObterTodos(int offset = 1, int limite = 50)
        {
            var logs = _mapper.Map<IEnumerable<LogSecViewModel>>(await _LogSecRepository.ObterTodos(offset, limite));

            if (!logs.Any()) return NotFound();

            return Ok(logs);
        }
    }
}