using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ephesto.Domain.Entities
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Pessoa(string cpf, string nome)
        {
            //if (string.IsNullOrEmpty(cpf))
                //throw new CpfInvalidoException();
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException();

            this.Cpf = cpf;
            this.Nome = nome;
        }

    }
}
