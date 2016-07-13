using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoFinal.Domain.Entities;

namespace ProjetoFinal.Dal.Contexts
{
    public class ProjetoFinalContext : DbContext
    {
        public ProjetoFinalContext()
            : base("Name=MemberContext")
        {
        }

        public DbSet<Usuario> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}