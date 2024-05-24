using FluentValidation;

using PortalComprasPublicas.Api.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Application.Validators
{
    /// <summary>
    /// Classe que define regras de validação das propriedades na criação ou atualizaçãoo de um produto
    /// </summary>
    public class ProdutoValidator : AbstractValidator<ProdutoViewModel>
    {
        public ProdutoValidator()
        {
            RuleFor(c => c.nome).NotEqual("string")
                .NotEmpty()
                .NotNull().WithMessage("Informe o nome do produto.");

            RuleFor(c => c.preco).GreaterThan(0).WithMessage("Informe o preço do produto");
        }
    }
}
