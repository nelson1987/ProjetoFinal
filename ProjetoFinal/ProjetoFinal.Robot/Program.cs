using System;
using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Service;
using ProjetoFinal.Domain.Interfaces.UnitOfWork;
using ProjetoFinal.Service.Services;

namespace ProjetoFinal.Robot
{
    internal class Program
    {
        //private IUsuarioRepository _iUsuarioRepository;
        public static IUsuarioService _usuarioService;
        private IUnitOfWork _unitOfWork;

        public Program()
        {
            _usuarioService = new UsuarioService(_unitOfWork);
        }

        private static void Main(string[] args)
        {
            Console.Write("");
            var perfilProcurado = new Perfil(1, "Novos");
            var usuarios = _usuarioService.ListarPorPerfil(perfilProcurado);
            Console.ReadKey();
        }
    }
}