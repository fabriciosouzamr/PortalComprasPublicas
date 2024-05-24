using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Interface
{
    /// <summary>
    /// Classe que implementa operações pra gerenciamento do produto
    /// </summary>
    public interface ILogSecRepository
    {
        Task<List<LogSec>> ObterTodos(int offset = 1, int limite = 50);
        Task Adicionar(LogSec entity);
    }
}
