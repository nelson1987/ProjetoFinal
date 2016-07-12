using System.Collections.Generic;
using ProjetoFinal.Domain.Entities;

namespace ProjetoFinal.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarPorPerfil(Perfil perfil);
    }
}