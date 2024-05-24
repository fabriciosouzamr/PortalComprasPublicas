/// <summary>
/// Classe de teste de controller de cliente
/// </summary>

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
    public class ClienteTest
    {
        private IClienteService _clienteServices;
        private ILogSecService _logSecServices;
        private ClienteController _clientesController;
        private readonly IMapper _mapper;
        IValidator<ClienteViewModel> _validator;

        public ClienteTest()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperConfig>();
            });

            this._mapper = mapperConfig.CreateMapper();
            this._clienteServices = new ClienteServicesFake();
            this._logSecServices = new LogSecServiceFake();
            this._validator = new ClienteValidator();
            this._clientesController = new ClienteController(this._clienteServices, this._logSecServices, this._validator, this._mapper);
        }

        [Fact]
        public void GetProdutos_RetornaOkResult()
        {
            // Act
            var okResult = _clientesController.ObterTodos();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetProdutos_RetornaTodosItens_OkResult()
        {
            // Act
            var okResult = _clientesController.ObterTodos(0, 1).Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ClienteViewModel>>(okResult.Value);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void AdicionarProduto_Retorna_CreatResult()
        {
            var clienteAdd = new ClienteViewModel
            {
                Id = Guid.NewGuid(),
                nome = "Produto Teste 4",
                endereco = "Ilhéus - Bahia - Brasil"
            };
            // Act
            var CreatedResult = _clientesController.Adcionar(clienteAdd).Result;
            // Assert
            Assert.IsType<ActionResult<ClienteViewModel>>(CreatedResult);
        }
    }
}
