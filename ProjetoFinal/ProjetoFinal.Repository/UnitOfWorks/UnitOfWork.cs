using ProjetoFinal.Domain.Interfaces.UnitOfWork;
using System;
using System.Data.Entity;

namespace ProjetoFinal.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        //public UnitOfWork(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        //{
        //    UsuarioRepository = usuarioRepository;
        //    PerfilRepository = perfilRepository;
        //}

        //public IUsuarioRepository UsuarioRepository { get; set; }
        //public IPerfilRepository PerfilRepository { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }


        public DbContext context;
        private bool disposed = false;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}