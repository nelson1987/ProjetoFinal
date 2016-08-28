using Ephesto.Domain.Entities;
using Ephesto.Domain.Interfaces.Repository;

namespace Ephesto.Domain.Interfaces.UnitOfWork
{
    public interface ILogRepository
    {
        string Nome { get; set; }
        void CriarLog(string nomePessoa);
    }

    public interface IPessoaRepository
    {
        void Excluir(Pessoa pessoa);
    }

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