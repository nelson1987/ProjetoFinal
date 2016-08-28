using Ephesto.Domain.Interfaces.UnitOfWork;

namespace Ephesto.Repository.Repositories
{
    public class LogRepository : ILogRepository
    {
        public string Nome { get; set; }
        public void CriarLog(string nomePessoa)
        {
            this.Nome = nomePessoa;
        }
    }
}
