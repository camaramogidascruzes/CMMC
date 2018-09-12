using System.Collections.Generic;
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
                    Login = usuario.Login,
                    Nome = usuario.Nome,
                    PasswordHash = usuario.PasswordHash,
                    DataUltimoLogin = usuario.DataUltimoLogin,
                    TerminoBloqueio = usuario.TerminoBloqueio,
                    Bloqueado = usuario.Bloqueado,
                    QuantidadeFalhasAcesso = usuario.QuantidadeFalhasAcesso,
                    Ip = usuario.Ip,
                    NecessarioAlterarSenha = usuario.NecessarioAlterarSenha
                };

                return identityuser;
            }
            return new IdentityUser();
        }

        public string UserName
        {
            get { return this.Nome; }
            set { this.Nome = value; }
        }

        private List<IdentityRole> _roles;
        public List<IdentityRole> Roles
        {
            get { return _roles ?? (_roles = new List<IdentityRole>()); }
            set { _roles = value; }
        }

    }
}