using ProjetoFinal.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoFinal.Domain.Interfaces.Service
{
    public interface IUsuarioService
    {
        List<Usuario> ListarPorPerfil(Perfil perfil);
        void CriarPerfisDeUsuario();
    }
}