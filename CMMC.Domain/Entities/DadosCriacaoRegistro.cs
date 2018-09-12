using System;

namespace CMMC.Domain.Entities
{
    public class DadosCriacaoRegistro
    {
        public DadosCriacaoRegistro(string usuario)
        {
            DataCriacao = DateTime.Now;
            UsuarioCriacao = usuario;
        }

        public DateTime DataCriacao { get; set; }
        public string UsuarioCriacao { get; set; }

    }
}
