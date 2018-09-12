using System.Collections.Generic;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Domain.Entities.RedeSemFio
{
    public class CategoriaUsuario : CriacaoAlteracaoBasicEntity
    {
        public CategoriaUsuario(string usuario):base(usuario)
        {
            Grupos = new List<Grupo>();
        }

        public string Nome { get; set; }
        public int Validade { get; set; }
        public int Quota { get; set; }

        public ICollection<Grupo> Grupos { get; set; }
    }
}