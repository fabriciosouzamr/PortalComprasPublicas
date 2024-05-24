/// <summary>
/// Classe de teste de controller de produto
/// </summary>
/// 
using PortalComprasPublicas.Tests.FakeDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicasApi.Controllers;
using PortalCompras.Produtos.boundedContext.Application.Validators;
using AutoMapper;
using PortalComprasPublicas.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using PortalComprasPublicas.Infrastructure.Data.Repository;
using PortalComprasPublicas.Application.Configuration;

namespace PortalComprasPublicas.Tests
{
    public class ProdutoTest
    {
        private IProdutoService _ProdutoServices;
        private ILogSecService _logSecServices;
        private ProdutoController _ProdutosController;
        private readonly IMapper _mapper;
        IValidator<ProdutoViewModel> _validator;

        public ProdutoTest()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperConfig>();
            });

            this._mapper = mapperConfig.CreateMapper();
            this._ProdutoServices = new ProdutoServicesFake();
            this._logSecServices = new LogSecServiceFake();
            this._validator = new ProdutoValidator();
            this._ProdutosController = new ProdutoController(this._ProdutoServices, this._logSecServices, this._validator, this._mapper);
        }

        [Fact]
        public void GetProdutos_RetornaOkResult()
        {
            // Act
            var okResult = _ProdutosController.ObterTodos().Result;
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void GetProdutos_RetornaTodosItens_OkResult()
        {
            // Act
            var okResult = _ProdutosController.ObterTodos(0, 5).Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ProdutoViewModel>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void AdicionarProduto_Retorna_CreatResult()
        {
            var ProdutoAdd = new ProdutoViewModel
            {
                Id = Guid.NewGuid(),
                nome = "Produto Teste 4",
                preco = 150
            };
            // Act
            var CreatedResult = _ProdutosController.Adcionar(ProdutoAdd).Result;
            // Assert
            Assert.IsType<ActionResult<ProdutoViewModel>>(CreatedResult);
        }
    }
}
