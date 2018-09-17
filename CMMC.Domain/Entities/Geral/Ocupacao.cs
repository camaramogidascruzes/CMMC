namespace CMMC.Domain.Entities.Geral
{
    public class Ocupacao
    {
        public Ocupacao()
        {
            Funcionario = new Funcionario();
            Cargo = new Cargo();
            DadosAlteracaoRegistro = new DadosAlteracaoRegistro();
            DadosAlteracaoRegistro = new DadosAlteracaoRegistro();
        }

        public int Idfuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

        public int Idcargo { get; set; }
        public Cargo Cargo { get; set; }

        public int Rgf { get; set; }

        public DadosCriacaoRegistro DadosCriacaoRegistro { get; set; }
        public DadosAlteracaoRegistro DadosAlteracaoRegistro { get; set; }
    }
}