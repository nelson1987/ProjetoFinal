using System;
using System.Collections.Generic;
using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Repository;

namespace ProjetoFinal.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public List<Usuario> BuscarPorPerfil(Perfil perfil)
        {
            throw new NotImplementedException();
        }
    }
}