namespace PortalComprasPublicas.Domain.Entity
{
    public class LogSec : EntityBase
    {
        /// <summary>
        /// Classe de dominio que representa um logsec do nosso negocio
        /// </summary>
        public DateTime dataHora { get; set; }
        public string rotina { get; set; }
        public string descricao { get; set; }
    }
}