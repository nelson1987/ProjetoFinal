namespace Ephesto.Domain.Interfaces.Repository
{
    public interface ILogRepository
    {
        string Nome { get; set; }

        void CriarLog(string nomePessoa);
    }
}