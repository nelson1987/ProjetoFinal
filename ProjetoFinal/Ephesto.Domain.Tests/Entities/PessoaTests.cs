using System;
using Ephesto.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ephesto.Crosscutting.Exceptions;

namespace Ephesto.Domain.Tests.Entities
{
    [TestClass]
    public class PessoaTests
    {
        [TestMethod]
        public void CriarPessoa()
        {
            string cpf = "12345678909";
            string nome = "Manoel da Silva";

            Pessoa pessoa = new Pessoa(cpf, nome);

            Assert.IsNotNull(pessoa);
            Assert.IsTrue(pessoa.Cpf == cpf);
            Assert.IsTrue(pessoa.Nome == nome);
        }

        [TestMethod]
        [ExpectedException(typeof(CpfInvalidoException))]
        public void NaoCriarPessoaSemCPF()
        {
            string nome = "Fulano da Silva";
            Pessoa pessoa = new Pessoa(null, nome);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NaoCriarPessoaSemNome()
        {
            string cpf = "12345678909";
            Pessoa pessoa = new Pessoa(cpf, null);
        }
    }
}
