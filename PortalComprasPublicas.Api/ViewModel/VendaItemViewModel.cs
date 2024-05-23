namespace PortalComprasPublicas.Api.ViewModel
{
    public class VendaItemViewModel : BaseViewModel
    {
        public Guid VendaId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Money { get; set; }

        /* EF Relation */
        public virtual VendaViewModel Venda { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }
    }
}
