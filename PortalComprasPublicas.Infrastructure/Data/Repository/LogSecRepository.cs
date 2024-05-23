using PortalComprasPublicas.Domain.Entity;
using PortalComprasPublicas.Domain.Interface;
using PortalComprasPublicas.Infrastructure.Data.Context;

namespace PortalComprasPublicas.Infrastructure.Data.Repository
{
    public class LogSecRepository : ILogSecRepository
    {
        //public LogSecRepository(SqlLiteDbContext context);

        public Task<List<LogSec>> ListarTodosSqlLite(int offset = 1, int limite = 50)
        {
            throw new NotImplementedException();
        }
    }
}
