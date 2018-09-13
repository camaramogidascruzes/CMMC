using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Infraestrutura.Identity
{
    public class IdentityUser : Usuario, IUser<int>
    {
        public IdentityUser()
        {
            _roles = new List<IdentityRole>();
        }

        public static IdentityUser FromUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                var identityuser = new IdentityUser()
                {
                    Id = usuario.Id,
                    Login = usuario.Login,
                    Nome = usuario.Nome,
                    PasswordHash = usuario.PasswordHash,
                    DataUltimoLogin = usuario.DataUltimoLogin,
                    TerminoBloqueio = usuario.TerminoBloqueio,
                    Bloqueado = usuario.Bloqueado,
                    QuantidadeFalhasAcesso = usuario.QuantidadeFalhasAcesso,
                    Ip = usuario.Ip,
                    NecessarioAlterarSenha = usuario.NecessarioAlterarSenha,
                };

                foreach (var ug in usuario.Grupos)
                {
                    if (ug.Grupo != null)
                    {
                        identityuser.Roles.Add(new IdentityRole(ug.Grupo));
                    }
                }

                return identityuser;
            }
            return new IdentityUser();
        }

        public Usuario ToUsuario()
        {
            return new Usuario()
            {
                Id = this.Id,
                Login = this.Login,
                Nome = this.Nome,
                PasswordHash = this.PasswordHash,
                DataUltimoLogin = this.DataUltimoLogin,
                TerminoBloqueio = this.TerminoBloqueio,
                Bloqueado = this.Bloqueado,
                QuantidadeFalhasAcesso = this.QuantidadeFalhasAcesso,
                Ip = this.Ip,
                NecessarioAlterarSenha = this.NecessarioAlterarSenha
            };
        }

        public string UserName
        {
            get { return this.Login; }
            set { this.Login = value; }
        }

        private List<IdentityRole> _roles;
        public List<IdentityRole> Roles
        {
            get { return _roles ?? (_roles = new List<IdentityRole>()); }
            set { _roles = value; }
        }

    }
}