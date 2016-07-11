using ProjetoFinal.Service.Services;
using System;
using System.Collections.Generic;
using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Repository;
using ProjetoFinal.Domain.Interfaces.Service;
using ProjetoFinal.Domain.Interfaces.UnitOfWork;

namespace ProjetoFinal.Robot
{
    class Program
    {
        //private IUsuarioRepository _iUsuarioRepository;
        public static IUsuarioService _usuarioService;
        private IUnitOfWork _unitOfWork;

        public Program()
        {
            _usuarioService = new UsuarioService(_unitOfWork);
        }

        static void Main(string[] args)
        {
            Console.Write("");
            Perfil perfilProcurado = new Perfil(1,"Novos");
            List<Usuario> usuarios = _usuarioService.ListarPorPerfil(perfilProcurado);
            Console.ReadKey();
        }
    }
}
