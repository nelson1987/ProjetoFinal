using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoFinal.Repository.Repositories
{
    public class UsuarioRepository : PadraoRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context)
            : base(context)
        {
        }

        public List<Usuario> ListarPorPerfil(Perfil perfil)
        {

            return this.DbSet.Where(c => c.Perfil.Equals(perfil)).ToList();
        }

        public override void Insert(Usuario entity)
        {
            entity.Login = "";
            base.Insert(entity);
        }

    }
}