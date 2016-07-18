using ProjetoFinal.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
        public virtual List<TEntity> Listar(int id)
        {
            return DbSet.ToList();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public TEntity Buscar()
        {
            return DbSet.FirstOrDefault();
        }
    }
}
