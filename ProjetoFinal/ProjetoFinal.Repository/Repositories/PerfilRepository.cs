using Ephesto.Domain.Entities;
using Ephesto.Domain.Interfaces.Repository;
using System.Data.Entity;

namespace Ephesto.Repository.Repositories
{
    public class PerfilRepository : PadraoRepository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(DbContext context)
            : base(context)
        {
        }

        public override void Insert(Perfil entity)
        {
            entity.Nome = "Nelson";
            base.Insert(entity);
        }

        public Perfil BuscarPorId(int id)
        {
            return base.Buscar();
        }
    }
}