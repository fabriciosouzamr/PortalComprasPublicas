using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Interface
{
    public interface ILogSecRepository
    {
        Task<List<LogSec>> ObterTodos(int offset = 1, int limite = 50);
        Task Adicionar(LogSec entity);
    }
}
