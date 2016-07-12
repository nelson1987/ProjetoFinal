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

        public Perfil BuscarPorId(int id)
        {
            return Buscar();
        }
    }
}