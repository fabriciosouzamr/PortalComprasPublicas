namespace PortalComprasPublicas.Domain.Entity
{
    public class LogSec : EntityBase
    {
        public DateTime dataHora { get; set; }
        public string rotina { get; set; }
        public string descricao { get; set; }
    }
}