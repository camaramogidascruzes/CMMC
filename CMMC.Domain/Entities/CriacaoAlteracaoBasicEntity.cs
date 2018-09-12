
using System;

namespace CMMC.Domain.Entities
{
    public class CriacaoAlteracaoBasicEntity : BasicEntity
    {
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
