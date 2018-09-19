

using System.Collections.Generic;
using CMMC.Domain.Entities.RedeSemFio;

namespace CMMC.Domain.Entities.Geral
{
    public class Grupo : CriacaoAlteracaoBasicEntity
    {
        public Grupo()
        {
            Usuarios = new List<UsuarioGrupo>();
        }

        public Grupo(string usuario) : base(usuario)
        {
            Usuarios = new List<UsuarioGrupo>();
        }

        public string Nome { get; set; }
        public bool Bloqueado { get; set; }

        public ICollection<UsuarioGrupo> Usuarios { get; set; }

        public int? IdCategoriaRedeSemFio { get; set; }
        public CategoriaUsuario CategoriaRedeSemFio { get; set; }
    }
}

