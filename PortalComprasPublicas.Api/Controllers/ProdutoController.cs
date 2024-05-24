using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public ProdutoController(IProdutoService ProdutoService,
                                 ILogSecService logSecService,
                                 IMapper mapper)
        {
            _produtoService = ProdutoService;
            _logSecService = logSecService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos(int offset = 1, int limite = 50)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterTodos(offset, limite));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produto = await Obter(id);

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProdutoViewModel>> Adcionar(ProdutoViewModel produto)
        {
            var ProdutoRet = await _produtoService.Adicionar(_mapper.Map<Produto>(produto));

            await _logSecService.Adicionar(rotina: "Produto - Adicionar", $"Id: {produto.Id} Nome: {produto.Nome}, Endereço: {produto.Preco.ToString("c")}");

            return CreatedAtAction(nameof(Adcionar), _mapper.Map<ProdutoViewModel>(ProdutoRet));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Atualizar(ProdutoViewModel produto)
        {
            var _Produto = await Obter(produto.Id);
            if (_Produto == null) return NotFound();

            await _produtoService.Atualizar(_mapper.Map<Produto>(produto));

            await _logSecService.Adicionar(rotina: "Produto - Atualizar", $"Id: {produto.Id} Nome: {produto.Nome}, Endereço: {produto.Preco.ToString("c")}");

            return Ok(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            var _Produto = await Obter(id);
            if (_Produto == null) return NotFound();

            await _logSecService.Adicionar(rotina: "Produto - Excluir", $"Id: {id}");

            return Ok(HttpStatusCode.NoContent);
        }
        private async Task<ProdutoViewModel> Obter(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoService.ObterPorId(id));
        }
    }
}