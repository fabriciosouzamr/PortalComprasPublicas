namespace PortalComprasPublicas.Domain.Entity
{
    public class LogSec : EntityBase
    {
        public DateTime DataHora { get; set; }
        public string Rotina { get; set; }
        public string Descricao { get; set; }
    }
}