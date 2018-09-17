namespace CMMC.Domain.Entities.Geral
{
    public class EmpresasTipos
    {
        public EmpresasTipos()
        {
            Empresa = new Empresa();
            TipoEmpresa = new TipoEmpresa();
            DadosCriacaoRegistro = new DadosCriacaoRegistro();
        }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        public int IdTipoEmpresa { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }

        public DadosCriacaoRegistro DadosCriacaoRegistro { get; set; }
    }
}