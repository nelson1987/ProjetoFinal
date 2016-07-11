using System;
using ProjetoFinal.Domain.Interfaces.Repository;
using ProjetoFinal.Domain.Interfaces.UnitOfWork;

namespace ProjetoFinal.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        //public UnitOfWork(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        //{
        //    UsuarioRepository = usuarioRepository;
        //    PerfilRepository = perfilRepository;
        //}

        public IUsuarioRepository UsuarioRepository { get; set; }
        public IPerfilRepository PerfilRepository { get; set; }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}