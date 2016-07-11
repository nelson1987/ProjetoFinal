using ProjetoFinal.Entities;

namespace ProjetoFinal.Factories
{
    public class FornecedorFactory
    {
        public Fornecedor CriarFornecedorConvencional(int id, int roboId)
        {
            return new Fornecedor {Id = id, RoboId = roboId};
        }

        public Fornecedor CriarFornecedorIndividual(int id, int roboId, int contatoId)
        {
            return new FornecedorIndividual {ContaId = contatoId, Id = id, RoboId = roboId};
        }
    }
}