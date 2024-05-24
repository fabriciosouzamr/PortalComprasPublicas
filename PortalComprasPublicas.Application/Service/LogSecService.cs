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
    /// <summary>
    /// Classe responsavel service do logsec, ela não ira herdar de baseservice e nem repositoryservice, por ter comportamento exclusivo.
    /// </summary>
    public class LogSecService : ILogSecService
    {
        private ILogSecRepository _logSecRepository;

        public LogSecService (ILogSecRepository logSecRepository)
        {
            this._logSecRepository = logSecRepository;
        }

        public async Task Adicionar(string rotina, string descricao)
        {
            var logSec = new LogSec() { dataHora = DateTime.Now, rotina = rotina, descricao = descricao };

            logSec.dataHora = DateTime.Now;
            await _logSecRepository.Adicionar(logSec);
        }

        public async Task<List<LogSec>> ObterTodos(int offset, int limite)
        {
            return await _logSecRepository.ObterTodos(offset, limite);
        }
    }
}
