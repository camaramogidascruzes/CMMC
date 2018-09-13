
using System;

namespace CMMC.Domain.Entities
{
    public class CriacaoAlteracaoBasicEntity : BasicEntity
    {
        protected CriacaoAlteracaoBasicEntity()
        {
            DadosCriacaoRegistro = new DadosCriacaoRegistro();
            DadosAlteracaoRegistro = new DadosAlteracaoRegistro();
            Excluido = false;
        }

        public CriacaoAlteracaoBasicEntity(string usuario)
        {
            DadosCriacaoRegistro = new DadosCriacaoRegistro(usuario);
            DadosAlteracaoRegistro = new DadosAlteracaoRegistro(usuario);
            Excluido = false;
        }
        
        public DadosCriacaoRegistro DadosCriacaoRegistro { get; set; }
        public DadosAlteracaoRegistro DadosAlteracaoRegistro { get; set; }
        public bool Excluido { get; set; }
    }
}
