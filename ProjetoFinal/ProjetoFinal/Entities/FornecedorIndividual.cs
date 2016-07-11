namespace ProjetoFinal.Entities
{
    public class FornecedorIndividual : Fornecedor
    {
        public int ContaId { get; set; }

        public bool RetornarStatusPagamento(FornecedorIndividual fornecedor)
        {
            return fornecedor.ContaId == 2;
        }
    }
}