// """

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Entity;
using PortalComprasPublicas.Domain.Interface;

using PortalComprasPublicasApi.Controllers;

namespace PortalComprasPublicas.Tests.FakeDb
{
    public class LogSecServiceFake : ILogSecService
    {
        List<LogSec> logs;

        public LogSecServiceFake() 
        {
            logs = new List<LogSec>
            {
                new LogSec { dataHora = DateTime.Now.AddDays(-1), rotina = "rotina X", descricao = "Teste 10" },
                new LogSec { dataHora = DateTime.Now.AddDays(-2), rotina = "rotina X", descricao = "Teste 11" },
                new LogSec { dataHora = DateTime.Now.AddDays(-3), rotina = "rotina X", descricao = "Teste 12" },
                new LogSec { dataHora = DateTime.Now.AddDays(-4), rotina = "rotina X", descricao = "Teste 13" },
                new LogSec { dataHora = DateTime.Now.AddDays(-5), rotina = "rotina X", descricao = "Teste 14" },
                new LogSec { dataHora = DateTime.Now.AddDays(-6), rotina = "rotina X", descricao = "Teste 15" },
                new LogSec { dataHora = DateTime.Now.AddDays(-7), rotina = "rotina X", descricao = "Teste 16" },
                new LogSec { dataHora = DateTime.Now.AddDays(-8), rotina = "rotina X", descricao = "Teste 17" },
                new LogSec { dataHora = DateTime.Now.AddDays(-9), rotina = "rotina X", descricao = "Teste 18" },
                new LogSec { dataHora = DateTime.Now.AddDays(-10), rotina = "rotina X", descricao = "Teste 19" },
                new LogSec { dataHora = DateTime.Now.AddDays(-11), rotina = "rotina X", descricao = "Teste 20" },
                new LogSec { dataHora = DateTime.Now.AddDays(-12), rotina = "rotina X", descricao = "Teste 21" },
                new LogSec { dataHora = DateTime.Now.AddDays(-13), rotina = "rotina X", descricao = "Teste 22" },
                new LogSec { dataHora = DateTime.Now.AddDays(-14), rotina = "rotina X", descricao = "Teste 23" },
                new LogSec { dataHora = DateTime.Now.AddDays(-15), rotina = "rotina X", descricao = "Teste 24" },
                new LogSec { dataHora = DateTime.Now.AddDays(-16), rotina = "rotina X", descricao = "Teste 25" },
                new LogSec { dataHora = DateTime.Now.AddDays(-17), rotina = "rotina X", descricao = "Teste 26" },
                new LogSec { dataHora = DateTime.Now.AddDays(-18), rotina = "rotina X", descricao = "Teste 27" },
                new LogSec { dataHora = DateTime.Now.AddDays(-19), rotina = "rotina X", descricao = "Teste 28" },
                new LogSec { dataHora = DateTime.Now.AddDays(-20), rotina = "rotina X", descricao = "Teste 29" },
                new LogSec { dataHora = DateTime.Now.AddDays(-21), rotina = "rotina X", descricao = "Teste 30" },
                new LogSec { dataHora = DateTime.Now.AddDays(-22), rotina = "rotina X", descricao = "Teste 31" },
                new LogSec { dataHora = DateTime.Now.AddDays(-23), rotina = "rotina X", descricao = "Teste 32" },
                new LogSec { dataHora = DateTime.Now.AddDays(-24), rotina = "rotina X", descricao = "Teste 33" },
                new LogSec { dataHora = DateTime.Now.AddDays(-25), rotina = "rotina X", descricao = "Teste 34" },
                new LogSec { dataHora = DateTime.Now.AddDays(-26), rotina = "rotina X", descricao = "Teste 35" },
                new LogSec { dataHora = DateTime.Now.AddDays(-27), rotina = "rotina X", descricao = "Teste 36" },
                new LogSec { dataHora = DateTime.Now.AddDays(-28), rotina = "rotina X", descricao = "Teste 37" },
                new LogSec { dataHora = DateTime.Now.AddDays(-29), rotina = "rotina X", descricao = "Teste 38" },
                new LogSec { dataHora = DateTime.Now.AddDays(-30), rotina = "rotina X", descricao = "Teste 39" },
            };
        }
        Task ILogSecService.Adicionar(string rotina, string descricao)
        {
            logs.Add(new LogSec() { dataHora = DateTime.Now, descricao = descricao, rotina = rotina});

            return Task.CompletedTask;
        }

        Task<List<LogSec>> ILogSecService.ObterTodos(int offset, int limite)
        {
            var _logs = logs.Skip(limite * (offset - 1))
            .Take(limite).ToList();

            return Task.FromResult(_logs);
        }
    }
}
