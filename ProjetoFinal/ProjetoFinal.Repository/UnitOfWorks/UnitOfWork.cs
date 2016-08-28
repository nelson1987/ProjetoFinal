using Ephesto.Domain.Interfaces.UnitOfWork;
using System;
using System.Data.Entity;
using Ephesto.Domain.Interfaces.Repository;

namespace Ephesto.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        public UnitOfWork(DbContext context, IUsuarioRepository usuarioRepository/*, IPerfilRepository perfilRepository*/)
        {
            this.context = context;
            this.UsuarioRepository = usuarioRepository;
            //PerfilRepository = perfilRepository;
        }
        //public IPerfilRepository PerfilRepository { get; set; }
        public IUsuarioRepository UsuarioRepository { get; set; }

        public ILogRepository LogRepositoryRepository { get; set; }

        public IPessoaRepository PessoaRepository { get; set; }

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

        //public UnitOfWork(DbContext context)
        //{
        //    this.context = context;
        //}


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