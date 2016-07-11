using System.Collections.Generic;
using ProjetoFinal.Domain.Entities;

namespace ProjetoFinal.Domain.Interfaces.Service
{
    public interface IUsuarioService
    {
        List<Usuario> ListarPorPerfil(Perfil perfil);
        void CriarPerfisDeUsuario();
    }
}