using ProjetoFinal.Domain.Entities;

namespace ProjetoFinal.Domain.Interfaces.Repository
{
    public interface IPerfilRepository
    {
        Perfil BuscarPorId(int id);
    }
}