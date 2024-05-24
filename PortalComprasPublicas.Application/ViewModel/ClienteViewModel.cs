namespace PortalComprasPublicas.Api.ViewModel
{
    /// <summary>
    /// Esta é uma classe que serve como objeto de passagem de dados entre a aplicação e o dominio.
    /// </summary>
    public class ClienteViewModel : BaseViewModel
    {
        public string nome { get; set; }
        /// <summary>
        /// Define o endereço completo do cliente
        /// </summary>
        /// <example>Rua X, n Y, ...</example>
        public string endereco { get; set; }
    }
}
