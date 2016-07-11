using System.Collections.Generic;

namespace ProjetoFinal.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public int RoboId { get; set; }
        public List<Contato> Contatos { get; set; }

        public void AlterarListaContatos(List<Contato> contatos)
        {
            Contatos = contatos;
        }
    }
}