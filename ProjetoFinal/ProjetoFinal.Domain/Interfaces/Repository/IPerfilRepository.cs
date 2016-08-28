using Ephesto.Domain.Entities;

namespace Ephesto.Domain.Interfaces.Repository
{
    public interface IPerfilRepository
    {
        Perfil BuscarPorId(int id);
    }
}