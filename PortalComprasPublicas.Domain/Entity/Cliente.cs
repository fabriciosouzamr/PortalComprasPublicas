using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string nome { get; set; }
        public string endereco { get; set; }
    }
}