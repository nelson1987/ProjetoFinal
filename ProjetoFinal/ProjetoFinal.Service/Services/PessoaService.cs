using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ephesto.Domain.Entities;
using Ephesto.Repository.Repositories;
using Ephesto.Domain.Interfaces.UnitOfWork;

namespace Ephesto.Service.Services
{
    public class PessoaService
    {
        public string NomeLog { get; private set; }

        private readonly IUnitOfWork _unitOfWork;

        public PessoaService(IUnitOfWork unitOfWork, string nomeLog)
        {
            _unitOfWork = unitOfWork;
            NomeLog = nomeLog;
        }

        public void Excluir(Pessoa pessoa)
        {
            _unitOfWork.PessoaRepository.Excluir(pessoa);
            _unitOfWork.LogRepositoryRepository.CriarLog(pessoa.Nome);
            NomeLog = _unitOfWork.LogRepositoryRepository.Nome;
        }
    }
}
