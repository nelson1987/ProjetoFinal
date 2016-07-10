using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }

        public bool Iniciando(Contato contato)
        {
            return contato.Status == 2;
        }
    }
}
