using System;

namespace CMMC.Domain.Entities.RedeSemFio
{
    public class CodigoAcesso : BasicEntity
    {
        public CodigoAcesso()
        {
            Usuario = new RedeSemFio.UsuarioRedeSemFio();
            DataEmissao = DateTime.MinValue;
        }

        public string Codigo { get; set; }
        public DateTime DataEmissao { get; set; }
        public int Validade { get; set; }
        public int Quota { get; set; }

        public int IdUsuarioRedeSemFio { get; set; }
        public UsuarioRedeSemFio Usuario { get; set; }
    }
}