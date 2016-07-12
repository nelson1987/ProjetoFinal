namespace ProjetoFinal.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        //IUsuarioRepository UsuarioRepository { get; }
        //IPerfilRepository PerfilRepository { get; }
        void Commit();
        void Rollback();
    }
}