using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using PortalComprasPublicas.Api.ViewModel;

namespace PortalCompras.Produtos.boundedContext.Application.Validators
{
    /// <summary>
    /// Classe que define regras de validação das propriedades na criação ou atualização de um cliente
    /// </summary>
    public class ClienteValidator : AbstractValidator<ClienteViewModel>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.nome).NotEqual("string")
                .NotEmpty()
                .NotNull().WithMessage("Informe o nome do cliente.");

            RuleFor(c => c.endereco).NotEqual("string")
                .NotEmpty()
                .NotNull().WithMessage("Informe o endereço do cliente.");
        }
    }
}
