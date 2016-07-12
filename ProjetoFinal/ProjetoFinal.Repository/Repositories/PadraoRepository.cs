using System.Data.Entity;
using System.Linq;
using ProjetoFinal.Repository.Interfaces;

namespace ProjetoFinal.Repository.Repositories
{
    public abstract class PadraoRepository<TEntity> : IPadraoRepository<TEntity> where TEntity : class
    {
        internal DbContext Context;
        internal DbSet<TEntity> DbSet;

        protected PadraoRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public TEntity Buscar()
        {
            return DbSet.FirstOrDefault();
        }
    }
}
