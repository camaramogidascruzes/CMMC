namespace CMMC.Domain.Entities.Geral
{
    public class FuncionarioContato : CriacaoAlteracaoBasicEntity
    {
        public FuncionarioContato()
        {
            Telefone = new InformacaoTelefone();
            Funcionario = new Funcionario();
        }

        public InformacaoTelefone Telefone { get; set; }

        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}