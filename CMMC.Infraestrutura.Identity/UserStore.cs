using CMMC.Data.Repositories.Geral;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.Repositories.Geral;

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
        private readonly IUsuarioRepository _usuariorepository;
        private readonly IGrupoRepository _gruporepository;

        public UserStore(IUsuarioRepository usuariorepository, IGrupoRepository gruporepository)
        {
            _usuariorepository = usuariorepository;
            _gruporepository = gruporepository;
        }

        #region IUSerStore

        public Task CreateAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _usuariorepository.Novo(user.ToUsuario());

            return _usuariorepository.Salvar();
        }

        public Task UpdateAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _usuariorepository.Alterar(user.ToUsuario());

            return _usuariorepository.Salvar();
        }

        public Task DeleteAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _usuariorepository.Excluir(user.ToUsuario());

            return _usuariorepository.Salvar();
        }

        public Task<IdentityUser> FindByIdAsync(int userId)
        {
            var usuario = _usuariorepository.LerUsuarioPorId(userId);
            return Task.FromResult<IdentityUser>(IdentityUser.FromUsuario(usuario.Result));
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            var usuario = _usuariorepository.BuscarPorNome(userName);
            return Task.FromResult<IdentityUser>(IdentityUser.FromUsuario(usuario.Result));
        }

        #endregion

        #region IQueryableUserStore

        public IQueryable<IdentityUser> Users
        {
            get { return _usuariorepository.BuscarUsuario().Cast<IdentityUser>(); }
        }

        #endregion 

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            _usuariorepository.Alterar(user.ToUsuario());
            return _usuariorepository.Salvar();
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

            var grupos = _usuariorepository.ListarGrupos(user.Id);

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

            var grupos = _usuariorepository.ListarGrupos(user.Id);


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

                    this._usuariorepository.Dispose();
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
            _usuariorepository.Alterar(user.ToUsuario());
            return _usuariorepository.Salvar();
        }

        public Task<int> IncrementAccessFailedCountAsync(IdentityUser user)
        {
            user.QuantidadeFalhasAcesso++;
            _usuariorepository.Alterar(user.ToUsuario());
            _usuariorepository.Salvar();
            return Task.FromResult<int>(user.QuantidadeFalhasAcesso);
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user)
        {
            user.QuantidadeFalhasAcesso = 0;
            _usuariorepository.Alterar(user.ToUsuario());
            return _usuariorepository.Salvar();
            
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
