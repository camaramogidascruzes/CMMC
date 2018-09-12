using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CMMC.Infraestrutura.Identity
{
    public class RoleStore : IRoleStore<IdentityRole, int>, IQueryableRoleStore<IdentityRole, int>
    {
        public Task CreateAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> FindByIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IdentityRole> Roles { get; }
    }
}