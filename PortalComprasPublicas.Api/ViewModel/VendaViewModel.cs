namespace PortalComprasPublicas.Api.ViewModel
{
    public class VendaViewModel : BaseViewModel
    {
        public Guid ClienteId { get; set; }
        public DateTime DataVenda { get; set; }

        /* EF Relation */
        public virtual ClienteViewModel Cliente { get; set; }
    }
}
