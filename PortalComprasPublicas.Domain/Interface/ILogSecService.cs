using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Interface
{
    public interface ILogSecService
    {
        Task<List<LogSec>> ObterTodos(int offset = 1, int limite = 50);
        Task Adicionar(string rotina, string descricao);
    }
}
