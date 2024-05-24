namespace PortalComprasPublicas.Api.ViewModel
{
    /// <summary>
    /// Esta é uma classe que serve como objeto de passagem de dados entre a aplicação e o dominio.
    /// </summary>
    public class LogSecViewModel
    {
        public DateTime DataHora { get; set; }
        /// <summary>
        /// Define o nome da rotina
        /// </summary>
        public string Rotina { get; set; }
        /// <summary>
        /// Define a descrição do evento
        /// </summary>
        public string Descricao { get; set; }
    }
}
