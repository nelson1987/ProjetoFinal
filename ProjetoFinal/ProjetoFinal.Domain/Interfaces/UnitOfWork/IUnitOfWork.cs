using Ephesto.Domain.Interfaces.Repository;

namespace Ephesto.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; set; }

        ILogRepository LogRepositoryRepository { get; set; }

        IPessoaRepository PessoaRepository { get; set; }

        //IPerfilRepository PerfilRepository { get; }

        void Commit();

        void Rollback();
    }
}