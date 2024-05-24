using System.Globalization;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

namespace PortalCompras.Produtos.boundedContext.Application.Validators
{
    /// <summary>
    /// Classe de extensão pra fazer o registro das dependencia do FluentValdator que faz validação das propriedade enviados pelo produto
    /// </summary>
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Type assemblyContainingValidators)
        {
            services.AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssemblyContaining(assemblyContainingValidators);
                conf.AutomaticValidationEnabled = false;
                conf.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            });

            return services;
        }

        public static List<MessageValidatorResult>? GetErrors(this ValidationResult result)
        {
            return result.Errors?.Select(error => new MessageValidatorResult(error.PropertyName, error.ErrorMessage)).ToList();
        }
    }
}
