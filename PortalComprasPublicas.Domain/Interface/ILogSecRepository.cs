using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Interface
{
    public interface ILogSecRepository
    {
        Task<List<LogSec>> ListarTodosSqlLite(int offset = 1, int limite = 50);
    }
}
