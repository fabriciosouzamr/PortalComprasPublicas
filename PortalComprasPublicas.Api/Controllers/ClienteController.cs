using System.Net;
using AutoMapper;

using Azure.Core;

using Microsoft.AspNetCore.Mvc;

using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;

namespace PortalComprasPublicasApi.Controllers
{
    /// <summary>
    /// Esta classe foi desenvolvida pra cadastro de cliente em uma base MySql
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;
        private readonly ILogSecService _logSecService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService,
                                 ILogSecService logSecService,
                                 IMapper mapper)
        {
            _clienteService = clienteService;
            _logSecService = logSecService;
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
        [ProducesResponseType((StatusCodes.Status200OK), Type = typeof(DateTime))]
        public IActionResult Agora()
        {
            var agora = DateTime.Now;
            return Ok(new { Time = agora });
        }

        /// <summary>
        /// Lista os clientes paginados, cada pagina tem no maximo 50 registros
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>os clientes paginados</returns>
        /// <response code="200">Retorna os clientes cadastros paginados</response>       
        /// <response code="204">Retorna caso não encontre clientes cadastrados</response>

        [HttpGet]
        [ProducesResponseType((StatusCodes.Status200OK), Type = typeof(List<dynamic>))]
        [ProducesResponseType((StatusCodes.Status404NotFound))]
        public async Task<IActionResult> ObterTodos(int offset = 1, int limite = 50)
        {
            var clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteService.ObterTodos(offset, limite));

            if (!clientes.Any()) return NotFound();

            return Ok(clientes);
        }

        /// <summary>
        /// Retorno o cliente de acordo id informado
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>o cliente pesquisa</returns>
        /// <response code="200">Retorna o cliente pesquisado</response>       
        /// <response code="204">Retorna caso não encontre o cliente pesquisado</response>

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(Guid id)
        {
            var cliente = await Obter(id);

            if (cliente == null) return NotFound();

            return cliente;
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///  {
        ///      "nome": "nome do cliente",
        ///      "endereco": "endereço do cliente"
        ///   }     
        ///</remarks>
        /// <returns>Um cliente cadastro</returns>
        /// <response code="201">Retorna o cliente cadastrado</response>
        /// <response code="400">Retorna erros de validação de campos do dominio</response>

        [HttpPost]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteViewModel>> Adcionar(ClienteViewModel cliente)
        {
            var _cliente = await _clienteService.Adicionar(_mapper.Map<Cliente>(cliente));

            await _logSecService.Adicionar(rotina: "Cliente - Adicionar", $"Id: {cliente.Id} Nome: {cliente.Nome}, Endereço: {cliente.Endereco}");

            return CreatedAtAction(nameof(Adcionar), _mapper.Map<ClienteViewModel>(_cliente));
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///  {
        ///     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///      "nome": "nome do cliente",
        ///      "endereco": "endereço do cliente"
        ///   }     
        ///</remarks>
        /// <returns>Um produto Atualizado</returns>
        /// <response code="204">Não retornado os dados já que o mesmo já estão sendo enviados</response>
        /// <response code="400">Retorna erros de validação de campos do dominio</response>
        /// <response code="40r">Retorna se o cliente que está sendo atualizado não existir</response>

        [HttpPut]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Atualizar(ClienteViewModel cliente)
        {
            var _cliente = await Obter(cliente.Id);
            if (_cliente == null) return NotFound();

            await _clienteService.Atualizar(_mapper.Map<Cliente>(cliente));

            await _logSecService.Adicionar(rotina: "Cliente - Atualizar", $"Id: {cliente.Id} Nome: {cliente.Nome}, Endereço: {cliente.Endereco}");

            return Ok(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Exclui um cliente por id
        /// </summary>
        /// <remarks>
        /// 
        ///</remarks>
        /// <returns></returns>
        /// <response code="204">Não retornado os dados</response>
        /// <response code="400">Retorna erros de validação de campos do dominio</response>
        /// <response code="404">Retorna se o cliente que está sendo excluído não existir</response>

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteViewModel>> Excluir(Guid id)
        {
            var _cliente = await Obter(id);
            if (_cliente == null) return NotFound();

            await _clienteService.Remover(id);

            await _logSecService.Adicionar(rotina: "Cliente - Exluir", $"Id: {id}");

            return Ok(HttpStatusCode.NoContent);
        }

        private async Task<ClienteViewModel> Obter(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteService.ObterPorId(id));
        }
    }
}