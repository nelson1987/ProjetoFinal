using Ephesto.Domain.Entities;

namespace Ephesto.Domain.Interfaces.Repository
{
    public interface IPessoaRepository
    {
        void Excluir(Pessoa pessoa);
    }
}