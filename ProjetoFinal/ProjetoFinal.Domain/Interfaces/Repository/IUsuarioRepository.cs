using ProjetoFinal.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoFinal.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarPorPerfil(Perfil perfil);
    }
}