namespace CMMC.Domain.Entities.Geral
{
    public class EmpresaContato : CriacaoAlteracaoBasicEntity
    {
        public EmpresaContato()
        {
            Telefone = new InformacaoTelefone();
            Empresa = new Empresa();
        }

        public string Nome { get; set; }
        public InformacaoTelefone Telefone { get; set; }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }
}