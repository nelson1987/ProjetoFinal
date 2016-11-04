using System.Data.Entity;
using Ephesto.Domain.Entities;
using Ephesto.Domain.Interfaces.Repository;
using Ephesto.Domain.Interfaces.UnitOfWork;

namespace Ephesto.Repository.Repositories
{
    public class PessoaRepository : PadraoRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(DbContext context)
            : base(context)
        {
        }

        public void Excluir(Pessoa pessoa)
        {
            throw new System.NotImplementedException();
        }
    }
}
