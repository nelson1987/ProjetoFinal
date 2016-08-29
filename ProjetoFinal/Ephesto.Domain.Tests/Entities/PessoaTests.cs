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
    }using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace PojetoFinal.Domain.Tests.Entities
{
    [TestClass]
    public class Tester
    {
        [TestMethod]
        public void TestarAutoMapperComConstrutor()
        {
            Mapper.Initialize(
                cfg => cfg.CreateMap<PessoaVM, Pessoa>()
                    .ConstructUsing(x => new Pessoa(x.NomePessoa, x.DocumentoPessoa, x.IdadePessoa))
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                );

            var modeloVM = new PessoaVM
            {
                NomePessoa = "Manoel da Silva",
                IdadePessoa = 25,
                DocumentoPessoa = "12345678909"
            };

            Pessoa pessoa = Mapper.Map<PessoaVM, Pessoa>(modeloVM);
            pessoa.ValidarMaioridadePenal();

            Assert.AreEqual(pessoa.Nome, modeloVM.NomePessoa);
            Assert.IsTrue(pessoa.MaioridadePenal == true);
        }
    }

    public class PessoaVM
    {
        public string NomePessoa { get; set; }
        public string DocumentoPessoa { get; set; }
        public int IdadePessoa { get; set; }
    }

    public class ObjectTo
    {
        private readonly string _name;

        public ObjectTo(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Age { get; set; }
    }

    [TestClass]
    public class PessoaTests
    {
        private Pessoa _pessoa;

        [TestInitialize]
        public void Setup()
        {
            //_pessoa = new Pessoa();
        }

        [TestMethod]
        public void CriarLogQuandoUmaPessoaForExcluida()
        {
            string cpf = "12345678909";
            string nome = "Alexandre";

            _pessoa = new Pessoa(nome, cpf, 1);

            LogRepository logRepository = new LogRepository();
            PessoaService service = new PessoaService(logRepository);
            service.Excluir(_pessoa);
            Assert.AreEqual(_pessoa.Nome, logRepository.GetNome());
        }

        [TestMethod]
        public void ValidarCpfQuandoCriar()
        {
            string cpf = "12345678909";
            string nome = "Manoel da Silva";

            Pessoa pessoa = new Pessoa(nome, cpf, 1);

            Assert.IsNotNull(pessoa);
            Assert.IsTrue(pessoa.Cpf == cpf);
            Assert.IsTrue(pessoa.Nome == nome);
        }

        [TestMethod]
        [ExpectedException(typeof(CpfInvalidoException))]
        public void CriarPessoaApenasComCPFValido()
        {
            string cpf = null;
            string nome = "Manoel da Silva";

            Pessoa pessoa = new Pessoa(nome, cpf, 1);

            Assert.IsNotNull(pessoa);
            Assert.IsTrue(pessoa.Cpf == cpf);
            Assert.IsTrue(pessoa.Nome == nome);
        }

        [TestMethod]
        public void ValidarSeCom17AnosPodeSerPreso()
        {
            _pessoa = new Pessoa("Eliana Nogueira", "12345678909", 17);
            _pessoa.ValidarMaioridadePenal();
            Assert.IsTrue(_pessoa.MaioridadePenal == false);
        }

        [TestMethod]
        public void ValidarSeCom21AnosPodeSerPreso()
        {
            _pessoa = new Pessoa("Eliana Nogueira", "12345678909", 21);
            _pessoa.ValidarMaioridadePenal();
            Assert.IsTrue(_pessoa.MaioridadePenal == true);
        }

        [TestMethod]
        public void ValidarSeCom17AnosPodeSeCasar()
        {
            _pessoa = new Pessoa("Eliana Nogueira", "12345678909", 17);
            _pessoa.ValidarMaioridadeCivil();
            Assert.IsTrue(_pessoa.MaioridadeCivil == false);
        }

        [TestMethod]
        public void ValidarSeCom18AnosPodeSeCasar()
        {
            _pessoa = new Pessoa("Eliana Nogueira", "12345678909", 18);
            _pessoa.ValidarMaioridadeCivil();
            Assert.IsTrue(_pessoa.MaioridadeCivil == true);
        }

        [TestMethod]
        public void ValidarSeCom15AnosPodeVotar()
        {
            _pessoa = new Pessoa("Eliana Nogueira", "12345678909", 15);
            _pessoa.ValidarDireitoAVoto();
            Assert.IsTrue(_pessoa.DireitoAVoto == false);
        }

        [TestMethod]
        public void ValidarSeCom17AnosPodeVotar()
        {
            _pessoa = new Pessoa("Eliana Nogueira", "12345678909", 17);
            _pessoa.ValidarDireitoAVoto();
            Assert.IsTrue(_pessoa.DireitoAVoto == true);
        }

    }

    public class Pessoa
    {
        private readonly string _nome;
        private readonly string _cpf;
        private readonly int _idade;
        public bool _maiorDeIdadePenal { get; private set; }
        public bool _maiorDeIdadeCivil { get; private set; }
        public bool _direitoAVoto { get; private set; }

        public Pessoa(string nome, string cpf, int idade)
        {
            isValid(nome, cpf, idade);

            _nome = nome;
            _cpf = cpf;
            _idade = idade;
        }

        public string Nome
        {
            get { return _nome; }
        }

        public string Cpf
        {
            get { return _cpf; }
        }

        public int Idade
        {
            get { return _idade; }
        }

        public bool MaioridadePenal
        {
            get { return _maiorDeIdadePenal; }
            private set
            {
                if (this._idade >= 21)
                    this._maiorDeIdadePenal = true;
                else
                    this._maiorDeIdadePenal = false;
            }
        }

        public bool MaioridadeCivil
        {
            get { return _maiorDeIdadeCivil; }
            private set
            {

                if (this._idade >= 18)
                    this._maiorDeIdadeCivil = true;
                else
                    this._maiorDeIdadeCivil = false;
            }
        }

        public bool DireitoAVoto
        {
            get { return _direitoAVoto; }
            private set
            {
                if (this._idade >= 16)
                    this._direitoAVoto = true;
                else
                    this._direitoAVoto = false;
            }
        }

        public void ValidarMaioridadePenal()
        {
            if (this._idade >= 21)
                this._maiorDeIdadePenal = true;
            else
                this._maiorDeIdadePenal = false;
        }

        public void ValidarMaioridadeCivil()
        {
            if (this._idade >= 18)
                this._maiorDeIdadeCivil = true;
            else
                this._maiorDeIdadeCivil = false;
        }

        public void ValidarDireitoAVoto()
        {
            if (this._idade >= 16)
                this._direitoAVoto = true;
            else
                this._direitoAVoto = false;
        }

        private void isValid(string nome, string cpf, int? idade)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new CpfInvalidoException();

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException();

            if (idade == 0)
                throw new ArgumentOutOfRangeException();
        }
    }

    public class PessoaService
    {
        private PessoaRepository repository;
        private LogRepository logRepository;
        public PessoaService(LogRepository log)
        {
            repository = new PessoaRepository();
            logRepository = log;
        }
        public void Excluir(Pessoa pessoa)
        {
            repository.Excluir(pessoa);
            logRepository.CriarLog(pessoa.Nome);
        }
    }

    public class PessoaRepository
    {
        public void Excluir(Pessoa Pessoa)
        {

        }
    }

    public class LogRepository : IGeradorLog
    {
        private string _nome;

        public void CriarLog(string nomePessoa)
        {
            _nome = nomePessoa;
        }

        public string GetNome()
        {
            return _nome;
        }
    }

    public interface IGeradorLog
    {
        void CriarLog(string nomePessoa);
        string GetNome();
    }

    public class CpfInvalidoException : ProjetoFinalException
    {
        public CpfInvalidoException() : base()
        {
        }
        public CpfInvalidoException(string message) : base(message)
        {
        }
        public CpfInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public abstract class ProjetoFinalException : Exception
    {
        public ProjetoFinalException() : base()
        {
        }
        public ProjetoFinalException(string message) : base(message)
        {
        }
        public ProjetoFinalException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

}
