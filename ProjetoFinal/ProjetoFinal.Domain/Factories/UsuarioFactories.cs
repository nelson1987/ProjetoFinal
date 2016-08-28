using Ephesto.Domain.Entities;
using System;

namespace Ephesto.Domain.Factories
{
    public class UsuarioFactories
    {
        public Usuario CriarUsuarioAdministrador(string nome, string login, string senha, string email, int perfilId)
        {
            var novoAdministrador = new Usuario(nome, login, senha, email, perfilId);
            if (!novoAdministrador.Validar(novoAdministrador))
                throw new Exception();
            return novoAdministrador;
        }

        public Usuario CriarUsuarioContratante(string nome, string login, string senha, string email, int contratanteId)
        {
            var novoContratante = new UsuarioContratante(nome, login, senha, email, contratanteId);
            if (!novoContratante.Validar(novoContratante))
                throw new Exception();
            return novoContratante;
        }
    }
}