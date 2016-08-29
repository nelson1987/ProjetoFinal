using Ephesto.Domain.Entities;
using System.Collections.Generic;

namespace Ephesto.Domain.Interfaces.Service
{
    public interface IUsuarioService
    {
        List<Usuario> ListarPorPerfil(Perfil perfil);

        void CriarPerfisDeUsuario();
    }
}