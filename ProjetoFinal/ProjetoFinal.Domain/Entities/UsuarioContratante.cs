using ProjetoFinal.Domain.ValueObjects;

namespace ProjetoFinal.Domain.Entities
{
    public class UsuarioContratante : Usuario
    {
        protected UsuarioContratante()
        {
        }

        public UsuarioContratante(Usuario usuario, int contratanteId)
            : base(usuario.Nome, usuario.Login, usuario.Senha, usuario.Email.Endereco)
        {
            ContratanteId = contratanteId;
        }

        public UsuarioContratante(string nome, string login, string senha, string email, int contratanteId)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = new Email(email);
            ContratanteId = contratanteId;
        }

        public UsuarioContratante(int contratanteId)
        {
            ContratanteId = contratanteId;
        }

        public int ContratanteId { get; set; }
    }
}