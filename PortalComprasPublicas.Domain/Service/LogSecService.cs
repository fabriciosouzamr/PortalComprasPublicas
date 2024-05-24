// """

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using PortalComprasPublicas.Domain.Entity;
using PortalComprasPublicas.Domain.Interface;

namespace PortalComprasPublicas.Domain.Service
{
    public class LogSecService : ILogSecService
    {
        private ILogSecRepository _logSecRepository;

        public LogSecService (ILogSecRepository logSecRepository)
        {
            this._logSecRepository = logSecRepository;
        }

        public async Task Adicionar(string rotina, string descricao)
        {
            var logSec = new LogSec() { DataHora = DateTime.Now, Rotina = rotina, Descricao = descricao };

            logSec.DataHora = DateTime.Now;
            await _logSecRepository.Adicionar(logSec);
        }

        public async Task<List<LogSec>> ObterTodos(int offset, int limite)
        {
            return await _logSecRepository.ObterTodos(offset, limite);
        }
    }
}
