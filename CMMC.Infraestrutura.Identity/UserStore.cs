using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMMC.Domain.Interfaces.Services.Geral;

namespace CMMC.Infraestrutura.Identity
{
    public class UserStore : 
        IDisposable,
        IUserStore<IdentityUser, int>, 
        IQueryableUserStore<IdentityUser, int>, 
        IUserPasswordStore<IdentityUser, int>,
        IUserRoleStore<IdentityUser, int>,
        IUserLockoutStore<IdentityUser, int>,
        IUserTwoFactorStore<IdentityUser, int>

    {
        private readonly IUsuarioAppService _usuarioappservice;
        private readonly IGrupoAppService _grupoappservice;

        public UserStore(IUsuarioAppService usuarioappservice, IGrupoAppService grupoappservice)
        {
            _usuarioappservice = usuarioappservice;
            _grupoappservice = grupoappservice;
        }

        #region IUSerStore

        public Task CreateAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return _usuarioappservice.Novo(user.ToUsuario());
        }

        public Task UpdateAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return _usuarioappservice.Alterar(user.ToUsuario());
        }

        public Task DeleteAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return _usuarioappservice.Excluir(user.ToUsuario());
        }

        public Task<IdentityUser> FindByIdAsync(int userId)
        {
            var usuario = _usuarioappservice.LerUsuarioPorId(userId);
            return Task.FromResult<IdentityUser>(IdentityUser.FromUsuario(usuario.Result));
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            var usuario = _usuarioappservice.BuscarPorNome(userName);
            return Task.FromResult<IdentityUser>(IdentityUser.FromUsuario(usuario.Result));
        }

        #endregion

        #region IQueryableUserStore

        public IQueryable<IdentityUser> Users
        {
            get { return _usuarioappservice.BuscarUsuario().Cast<IdentityUser>(); }
        }

        #endregion 

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        #endregion

        #region IUserRoleStore

        public Task AddToRoleAsync(IdentityUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(IdentityUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var grupos = _usuarioappservice.ListarGrupos(user.Id);

            var nomes = new List<string>();

            foreach (var grupo in grupos.Result)
            {
                nomes.Add(grupo.Nome);
            }

            return Task.FromResult<System.Collections.Generic.IList<string>>(nomes);
        }

        public Task<bool> IsInRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var grupos = _usuarioappservice.ListarGrupos(user.Id);


            return Task.FromResult<bool>(grupos.Result.Any(g => g.Nome == roleName));
        }

        #endregion

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {

                    this._usuarioappservice.Dispose();
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion

        #region IUserLockoutStore

        public Task<DateTimeOffset> GetLockoutEndDateAsync(IdentityUser user)
        {
            var lockOutDate = user.TerminoBloqueio.HasValue ? user.TerminoBloqueio.Value : new DateTimeOffset(DateTime.UtcNow.AddMinutes(-5));
            return Task.FromResult<DateTimeOffset>(lockOutDate);
        }
        public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset lockoutEnd)
        {
            user.TerminoBloqueio = lockoutEnd.DateTime;
            user.Bloqueado = true;
            return Task.CompletedTask;
        }

        public Task<int> IncrementAccessFailedCountAsync(IdentityUser user)
        {
            user.QuantidadeFalhasAcesso++;
            return Task.FromResult<int>(user.QuantidadeFalhasAcesso);
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user)
        {
            user.QuantidadeFalhasAcesso = 0;
            return Task.CompletedTask;

        }

        public Task<int> GetAccessFailedCountAsync(IdentityUser user)
        {
            return Task.FromResult<int>(user.QuantidadeFalhasAcesso);
        }

        public Task<bool> GetLockoutEnabledAsync(IdentityUser user)
        {
            return Task.FromResult<bool>(true);
        }

        public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled)
        {
            return Task.FromResult(enabled);
        }



        #endregion

        #region IUserTwoFactorStore
        public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled)
        {
            return Task.FromResult(enabled);
        }

        public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task CreateAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }
        #endregion




    }
}
