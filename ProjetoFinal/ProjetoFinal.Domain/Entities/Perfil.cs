namespace ProjetoFinal.Domain.Entities
{
    public class Perfil
    {
        //private string p;
        //private int perfilId;

        protected Perfil()
        {
        }

        public Perfil(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}