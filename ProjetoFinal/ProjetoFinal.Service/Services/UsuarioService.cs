using System.Collections.Generic;
using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Repository;
using ProjetoFinal.Domain.Interfaces.Service;
using ProjetoFinal.Domain.Interfaces.UnitOfWork;
using ProjetoFinal.Repository.UnitOfWorks;

namespace ProjetoFinal.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = _unitOfWork.UsuarioRepository;
            _perfilRepository = _unitOfWork.PerfilRepository;
        }

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _unitOfWork = new UnitOfWork();
            _usuarioRepository = usuarioRepository;
            _perfilRepository = _unitOfWork.PerfilRepository;
        }

        public List<Usuario> ListarPorPerfil(Perfil perfil)
        {
            return _usuarioRepository.BuscarPorPerfil(perfil);
        }

        public void CriarPerfisDeUsuario()
        {
            //var perfilPessoal = _perfilRepository.BuscarPorId(1);
            _unitOfWork.Commit();
        }
    }
}