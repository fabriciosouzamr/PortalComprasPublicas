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
    public class ProdutoServicesFake : IProdutoService
    {
        List<Produto> produtos;

        public ProdutoServicesFake()
        {
            produtos = new List<Produto>
        {
            new Produto { nome = "Notebook", preco = GerarPreco(150, 500) },
            new Produto { nome = "Smartphone", preco = GerarPreco(150, 500) },
            new Produto { nome = "Tablet", preco = GerarPreco(150, 500) },
            new Produto { nome = "Monitor", preco = GerarPreco(150, 500) },
            new Produto { nome = "Impressora", preco = GerarPreco(150, 500) },
            new Produto { nome = "Mouse", preco = GerarPreco(150, 500) },
            new Produto { nome = "Teclado", preco = GerarPreco(150, 500) },
            new Produto { nome = "Fone de Ouvido", preco = GerarPreco(150, 500) },
            new Produto { nome = "Caixa de Som", preco = GerarPreco(150, 500) },
            new Produto { nome = "Roteador", preco = GerarPreco(150, 500) },
            new Produto { nome = "Câmera de Segurança", preco = GerarPreco(150, 500) },
            new Produto { nome = "HD Externo", preco = GerarPreco(150, 500) },
            new Produto { nome = "SSD", preco = GerarPreco(150, 500) },
            new Produto { nome = "Webcam", preco = GerarPreco(150, 500) },
            new Produto { nome = "Hub USB", preco = GerarPreco(150, 500) },
            new Produto { nome = "Cartão de Memória", preco = GerarPreco(150, 500) },
            new Produto { nome = "Acessório para Notebook", preco = GerarPreco(150, 500) },
            new Produto { nome = "Acessório para Smartphone", preco = GerarPreco(150, 500) },
            new Produto { nome = "Acessório para Tablet", preco = GerarPreco(150, 500) },
            new Produto { nome = "Acessório para Computador", preco = GerarPreco(150, 500) },
            new Produto { nome = "Kit de Limpeza para Eletrônicos", preco = GerarPreco(150, 500) },
            new Produto { nome = "Case para HD Externo", preco = GerarPreco(150, 500) },
            new Produto { nome = "Protetor de Tela para Smartphone", preco = GerarPreco(150, 500) },
            new Produto { nome = "Adaptador USB", preco = GerarPreco(150, 500) },
            new Produto { nome = "Carregador Portátil", preco = GerarPreco(150, 500) },
            new Produto { nome = "Estabilizador de Tensão", preco = GerarPreco(150, 500) },
            new Produto { nome = "Filtro de Linha", preco = GerarPreco(150, 500) },
            new Produto { nome = "Suporte para Notebook", preco = GerarPreco(150, 500) },
            new Produto { nome = "Suporte para Smartphone", preco = GerarPreco(150, 500) },
            new Produto { nome = "Cooler para Notebook", preco = GerarPreco(150, 500) },
            new Produto { nome = "Cabo HDMI", preco = GerarPreco(150, 500) }
        };
        }

        Task<Produto> IService<Produto>.Adicionar(Produto entity)
        {
            produtos.Add(entity);

            return Task.FromResult(entity);
        }

        Task<Produto> IService<Produto>.Atualizar(Produto entity)
        {
            if (produtos.Any(w => w.Id == entity.Id))
                produtos.First(w => w.Id == entity.Id).nome = entity.nome;

            return Task.FromResult(entity);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Task<Produto> IService<Produto>.ObterPorId(Guid id, params Expression<Func<Produto, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        Task<List<Produto>> IService<Produto>.ObterTodos(int offset, int limite, Expression<Func<Produto, object>> order)
        {
            var _produtos = produtos.Skip(limite * (offset - 1))
            .Take(limite).ToList();

            return Task.FromResult(_produtos);
        }

        Task<int> IService<Produto>.Remover(Guid id)
        {
            if (produtos.Any(w => w.Id == id))
                produtos.Remove(produtos.First(w => w.Id == id));

            return Task.FromResult(0);
        }
        static decimal GerarPreco(double min, double max)
        {
            Random random = new Random();
            return Math.Round((decimal)(min + (random.NextDouble() * (max - min))), 2);
        }
    }
}
