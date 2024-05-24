using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCompras.Produtos.boundedContext.Application.Validators
{
    /// <summary>
    /// Classe que retorna quais propriedades do objetos estão inválidas quando o cliente fazem PUT e POST na Api
    /// </summary>
    public class MessageValidatorResult
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public MessageValidatorResult(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
