// """

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using PortalComprasPublicas.Api.ViewModel;
using PortalComprasPublicas.Domain.Entities;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Domain.Service;

namespace PortalComprasPublicas.Tests.FakeDb
{
    public class ClienteServicesFake : IClienteService
    {
        List<Cliente> clientes = new List<Cliente>();

        public ClienteServicesFake() 
        {
            clientes = new List<Cliente>
            {
                new Cliente { nome = "Vincent Van Gogh",  endereco = "Rua Artista, 123 - São Paulo - SP, Brasil" },
                new Cliente { nome = "Pablo Picasso", endereco = "Avenida das Artes, 456 - Rio de Janeiro - RJ, Brasil" },
                new Cliente { nome = "Leonardo da Vinci", endereco = "Travessa do Pincel, 789 - Belo Horizonte - MG, Brasil" },
                new Cliente { nome = "Georgia O'Keeffe", endereco = "Alameda das Telas, 321 - Brasília - DF, Brasil" },
                new Cliente { nome = "Frida Kahlo", endereco = "Rua dos Pincéis, 567 - Salvador - BA, Brasil" },
                new Cliente { nome = "Claude Monet", endereco = "Avenida das Cores, 890 - Porto Alegre - RS, Brasil" },
                new Cliente { nome = "Salvador Dali", endereco = "Rua das Esculturas, 234 - Recife - PE, Brasil" },
                new Cliente { nome = "Michelangelo", endereco = "Avenida dos Artistas, 678 - Fortaleza - CE, Brasil" },
                new Cliente { nome = "Andy Warhol", endereco = "Travessa das Obras, 901 - Manaus - AM, Brasil" },
                new Cliente { nome = "Rembrandt", endereco = "Alameda das Galerias, 543 - Natal - RN, Brasil" },
                new Cliente { nome = "Edvard Munch", endereco = "Rua das Tintas, 234 - Florianópolis - SC, Brasil" },
                new Cliente { nome = "Jackson Pollock", endereco = "Avenida dos Pincéis, 789 - Curitiba - PR, Brasil" },
                new Cliente { nome = "Gustav Klimt", endereco = "Travessa das Esculturas, 123 - Goiânia - GO, Brasil" },
                new Cliente { nome = "Rene Magritte", endereco = "Alameda dos Pintores, 456 - Vitória - ES, Brasil" },
                new Cliente { nome = "Henri Matisse", endereco = "Rua das Obras, 890 - São Luís - MA, Brasil" }
            };
        }

        Task<Cliente> IService<Cliente>.Adicionar(Cliente entity)
        {
            clientes.Add(entity);

            return Task.FromResult(entity);
        }

        Task<Cliente> IService<Cliente>.Atualizar(Cliente entity)
        {
            if (clientes.Any(w => w.Id == entity.Id))
                clientes.First(w => w.Id == entity.Id).nome = entity.nome;

            return Task.FromResult(entity);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Task<Cliente> IService<Cliente>.ObterPorId(Guid id, params Expression<Func<Cliente, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        Task<List<Cliente>> IService<Cliente>.ObterTodos(int offset, int limite, Expression<Func<Cliente, object>> order)
        {
            var _clientes = clientes.Skip(limite * (offset - 1))
            .Take(limite).ToList();

            return Task.FromResult(_clientes);
        }

        Task<int> IService<Cliente>.Remover(Guid id)
        {
            if (clientes.Any(w => w.Id == id))
                clientes.Remove(clientes.First(w => w.Id == id));

            return Task.FromResult(0);
        }
    }
}
