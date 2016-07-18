using System.Data.Entity;
using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Repository;

namespace ProjetoFinal.Repository.Repositories
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