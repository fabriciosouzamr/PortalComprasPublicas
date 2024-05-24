using System.Net;
using AutoMapper;

using FluentValidation;

using Microsoft.AspNetCore.Mvc;
using PortalCompras.Produtos.boundedContext.Application.Validators;
using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Domain.Service;

namespace PortalComprasPublicasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        private readonly ILogSecService _logSecService;
        IValidator<ProdutoViewModel> _validator;

        public ProdutoController(IProdutoService ProdutoService,
                                 ILogSecService logSecService,
                                 IValidator<ProdutoViewModel> validator,
                                 IMapper mapper)
        {
            _produtoService = ProdutoService;
            _logSecService = logSecService;
            _validator = validator;
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
        /// Lista os produtos paginados, cada pagina tem no maximo 50 registros
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>os produtos paginados</returns>
        /// <response code="200">Retorna os produtos cadastros paginados</response>       
        /// <response code="204">Retorna caso não encontre produtos cadastrados</response>

        [HttpGet]
        [ProducesResponseType((StatusCodes.Status200OK), Type = typeof(List<dynamic>))]
        [ProducesResponseType((StatusCodes.Status404NotFound))]
        public async Task<IActionResult> ObterTodos(int offset = 1, int limite = 50)
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterTodos(offset, limite));

            if (!produtos.Any()) return NotFound();

            return Ok(produtos);
        }

        /// <summary>
        /// Retorno o produto de acordo id informado
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>o produto pesquisa</returns>
        /// <response code="200">Retorna o cliente pesquisado</response>       
        /// <response code="204">Retorna caso não encontre o cliente pesquisado</response>

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produto = await Obter(id);

            if (produto == null) return NotFound();

            return produto;
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///  {
        ///      "nome": "nome do produto",
        ///      "preco": "preço do produto"
        ///   }     
        ///</remarks>
        /// <returns>Um produto cadastro</returns>
        /// <response code="201">Retorna o produto cadastrado</response>
        /// <response code="400">Retorna erros de validação de campos do dominio</response>

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProdutoViewModel>> Adcionar(ProdutoViewModel produto)
        {
            var validation = await _validator.ValidateAsync(produto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.GetErrors());
            }

            produto.Id = Guid.NewGuid();
            var ProdutoRet = await _produtoService.Adicionar(_mapper.Map<Produto>(produto));

            await _logSecService.Adicionar(rotina: "Produto - Adicionar", $"Id: {produto.Id} Nome: {produto.nome}, Endereço: {produto.preco.ToString("c")}");

            return CreatedAtAction(nameof(Adcionar), _mapper.Map<ProdutoViewModel>(ProdutoRet));
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///  {
        ///     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///      "nome": "nome do produto",
        ///      "preco": "preço do produto"
        ///   }     
        ///</remarks>
        /// <returns>Um produto Atualizado</returns>
        /// <response code="204">Não retornado os dados já que o mesmo já estão sendo enviados</response>
        /// <response code="400">Retorna erros de validação de campos do dominio</response>
        /// <response code="40r">Retorna se o produto que está sendo atualizado não existir</response>

        [HttpPut]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Atualizar(ProdutoViewModel produto)
        {
            var validation = await _validator.ValidateAsync(produto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.GetErrors());
            }

            var _Produto = await Obter(produto.Id);
            if (_Produto == null) return NotFound();

            await _produtoService.Atualizar(_mapper.Map<Produto>(produto));

            await _logSecService.Adicionar(rotina: "Produto - Atualizar", $"Id: {produto.Id} Nome: {produto.nome}, Endereço: {produto.preco.ToString("c")}");

            return Ok(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Exclui um produto por id
        /// </summary>
        /// <remarks>
        /// 
        ///</remarks>
        /// <returns></returns>
        /// <response code="204">Não retornado os dados</response>
        /// <response code="400">Retorna erros de validação de campos do dominio</response>
        /// <response code="404">Retorna se o produto que está sendo excluído não existir</response>

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            var _Produto = await Obter(id);
            if (_Produto == null) return NotFound();

            await _produtoService.Remover(id);

            await _logSecService.Adicionar(rotina: "Produto - Excluir", $"Id: {id}");

            return Ok(HttpStatusCode.NoContent);
        }
        private async Task<ProdutoViewModel> Obter(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoService.ObterPorId(id));
        }
    }
}