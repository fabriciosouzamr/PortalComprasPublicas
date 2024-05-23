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
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
                                 IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> ObterTodos(int offset = 1, int limite = 50)
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos(offset, limite));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(Guid id)
        {
            var produto = await Obter(id);

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteViewModel>> Adcionar(ClienteViewModel cliente)
        {
            var ClienteRet = await _clienteRepository.Adicionar(_mapper.Map<Cliente>(cliente));

            return CreatedAtAction(nameof(Adcionar), _mapper.Map<ClienteViewModel>(ClienteRet));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Atualizar(ClienteViewModel cliente)
        {
            var _cliente = await Obter(cliente.Id);
            if (_cliente == null) return NotFound();

            await _clienteRepository.Atualizar(_mapper.Map<Cliente>(cliente));

            return Ok(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteViewModel>> Excluir(Guid id)
        {
            var _cliente = await Obter(id);
            if (_cliente == null) return NotFound();

            return Ok(HttpStatusCode.NoContent);
        }
        private async Task<ClienteViewModel> Obter(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
        }
    }
}