using PortalComprasPublicas.Domain.Entities;

namespace PortalComprasPublicas.Domain.Interface
{
    /// <summary>
    /// Interface que orquestra nossa camada Repository de infraestrutura que faz comunicação com o banco de dados. 
    /// </summary>

    public interface IProdutoService : IService<Produto>
    {
    }
}
