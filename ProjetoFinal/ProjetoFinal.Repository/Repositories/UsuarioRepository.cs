using System;
using System.Collections.Generic;
using System.Data.Entity;
using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Repository;

namespace ProjetoFinal.Repository.Repositories
{
    public class UsuarioRepository : PadraoRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }
        public List<Usuario> ListarPorPerfil(Perfil perfil)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Usuario entity)
        {
            entity.Login = "";
            base.Insert(entity);
        }

    }
}