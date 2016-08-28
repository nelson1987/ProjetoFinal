using Ephesto.Domain.Entities;
using Ephesto.Domain.Interfaces.Repository;
using Ephesto.Domain.Interfaces.Service;
using Ephesto.Domain.Interfaces.UnitOfWork;
using System.Collections.Generic;

namespace Ephesto.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Save(List<Usuario> members)
        {
            members.ForEach(m =>
            {
                if (m.Id == default(int))
                {
                    //_usuarioRepository.BuscarPorPerfil(m);
                }
            });
            _unitOfWork.Commit();
        }

        public List<Usuario> ListarPorPerfil(Perfil perfil)
        {
            return _unitOfWork.UsuarioRepository.ListarPorPerfil(perfil);
        }

        public void CriarPerfisDeUsuario()
        {
            //var perfilPessoal = _perfilRepository.BuscarPorId(1);
            _unitOfWork.Commit();
        }
    }
}