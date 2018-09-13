using System;

namespace CMMC.Domain.Entities
{
    public class DadosAlteracaoRegistro
    {
        public DadosAlteracaoRegistro()
        {
            DataUltimaAlteracao = DateTime.MinValue;
        }

        public DadosAlteracaoRegistro(string usuario)
        {
            DataUltimaAlteracao = DateTime.Now;
            UsuarioUltimaAlteracao = usuario;
        }

        public DateTime DataUltimaAlteracao { get; set; }
        public string UsuarioUltimaAlteracao { get; set; }
    }
}
