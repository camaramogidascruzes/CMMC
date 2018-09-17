namespace CMMC.Domain.Entities.Geral
{
    public class Parlamentar : CriacaoAlteracaoBasicEntity
    {
        public Parlamentar()
        {
            Setor = new Setor();
        }

        public string Nome { get; set; }
        public string NomeCompleto { get; set; }

        public int? IdSetor { get; set; }
        public Setor Setor { get; set; }
    }
}