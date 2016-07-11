using System.Collections.Generic;

namespace ProjetoFinal.Entities
{
    public class Cor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public enum EnumEspecie
    {
        Tilapia = 1,
        Lambari = 2,
        Carpa = 3
    }

    public class Peixe
    {
        private readonly IPeixeRepository _peixeRepository;

        public Peixe(IPeixeRepository peixeRepository)
        {
            _peixeRepository = peixeRepository;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public Cor Cor { get; set; }
        public EnumEspecie EnumEspecie { get; set; }

        public List<Peixe> GetPeixesIrmaos()
        {
            return _peixeRepository.GetPeixesPorEspecie(EnumEspecie);
        }

        public bool PodeViverCom(Peixe outroPeixe)
        {
            return EnumEspecie.Equals(outroPeixe.EnumEspecie);
        }
    }

    public interface IPeixeRepository
    {
        List<Peixe> GetTodosPeixes();
        List<Peixe> GePeixesPorCor(Cor cor);
        List<Peixe> GetPeixesPorEspecie(EnumEspecie especie);
        Peixe GetPeixePorId(int id);
    }
}