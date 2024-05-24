namespace PortalComprasPublicas.Domain.Entity
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Classe de dominio básica para os objetos de dominio do projeto
        /// </summary>
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}
