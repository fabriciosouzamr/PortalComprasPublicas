namespace PortalComprasPublicas.Api.ViewModel
{
    /// <summary>
    /// Esta é uma classe que serve como objeto de passagem de dados entre a aplicação e o dominio.
    /// </summary>
    public class ProdutoViewModel : BaseViewModel
    {
        public string nome { get; set; }
        /// <summary>
        /// Define o preço do produto
        /// </summary>
        /// <example>1.500</example>
        public decimal preco { get; set; }
    }
}
