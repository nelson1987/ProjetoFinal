namespace ProjetoFinal.Domain.ValueObjects
{
    public class Email
    {
        protected Email()
        {
        }

        public Email(string enderecoEmail)
        {
            Endereco = enderecoEmail;
        }

        public string Endereco { get; set; }

        public bool Validar(Email email)
        {
            return email.Endereco.Length > 10 && email.Endereco.Contains("@");
        }
    }
}