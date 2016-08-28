using Ephesto.Domain.ValueObjects;

namespace Ephesto.Domain.Entities
{
    public class Usuario
    {
        protected Usuario(string nome, string login, string senha, string email)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = new Email(email);
        }

        public Usuario(string nome, string login, string senha, string email, int perfilId)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = new Email(email);
            Perfil = new Perfil(perfilId, "");
        }

        protected Usuario()
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Email Email { get; set; }
        public Perfil Perfil { get; set; }

        public bool Validar(Usuario usuario)
        {
            return usuario.Email.Validar(usuario.Email);
        }
    }
}