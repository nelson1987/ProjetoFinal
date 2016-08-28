using Ephesto.Domain.Entities;
using System.Collections.Generic;

namespace Ephesto.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarPorPerfil(Perfil perfil);
    }
}