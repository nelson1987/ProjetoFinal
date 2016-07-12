using System.Collections.Generic;
using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Repository;
using ProjetoFinal.Domain.Interfaces.Service;
using ProjetoFinal.Domain.Interfaces.UnitOfWork;

namespace ProjetoFinal.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
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
            return _usuarioRepository.ListarPorPerfil(perfil);
        }

        public void CriarPerfisDeUsuario()
        {
            //var perfilPessoal = _perfilRepository.BuscarPorId(1);
            _unitOfWork.Commit();
        }
    }
}