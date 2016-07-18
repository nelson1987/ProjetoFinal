using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Service;
using System;
using System.Linq;

namespace ProjetoFinal.Robot
{
    public class Repositorio
    {
        private static IUsuarioService _usuarioService;

        public Repositorio(IUsuarioService usuarioRepository)
        {
            _usuarioService = usuarioRepository;
        }

        public Usuario PorPerfil()
        {
            var perfilProcurado = new Perfil(1, "Novos");
            var usuarios = _usuarioService.ListarPorPerfil(perfilProcurado);
            return usuarios.FirstOrDefault();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //IoC.Bootstraper();
            Console.Write("");
            var perfilProcurado = new Perfil(1, "Novos");
            //Repositorio repo = new Repositorio();

            //Console.WriteLine(usuarios.FirstOrDefault().Login);
            Console.ReadKey();
        }
    }
}