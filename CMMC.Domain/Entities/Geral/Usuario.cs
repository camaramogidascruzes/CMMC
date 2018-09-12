

using System;
using System.Collections.Generic;
using System.Linq;

namespace CMMC.Domain.Entities.Geral
{
    public class Usuario : BasicEntity
    {
        public Usuario()
        {
            DataUltimoLogin = DateTime.MinValue;
            TerminoBloqueio = DateTime.MinValue;
            Grupos = new List<UsuarioGrupo>();
        }

        public string Login { get; set; }
        public string Nome { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public DateTime? TerminoBloqueio { get; set; }
        public bool Bloqueado { get; set; }
        public int QuantidadeFalhasAcesso { get; set; }
        public string Ip { get; set; }
        public bool NecessarioAlterarSenha { get; set; }

        public ICollection<UsuarioGrupo> Grupos { get; set; }

        public void AdicionarGrupo(Grupo grupo, string usuario)
        {
            if (!this.Grupos.All(ug => ug.IdGrupo == grupo.Id && ug.IdUsuario == this.Id))
            {
                Grupos.Add(new UsuarioGrupo(this.Id, grupo.Id, usuario));
            }
        }

    }
}
