using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
