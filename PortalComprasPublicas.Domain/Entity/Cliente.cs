using PortalComprasPublicas.Domain.Entity;

namespace PortalComprasPublicas.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}