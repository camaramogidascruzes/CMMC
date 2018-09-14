using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CMMC.Infraestrutura.Identity
{
    public class SignInManager : SignInManager<IdentityUser, int>
    {
        public SignInManager(UserManager<IdentityUser, int> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {

        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
        {
            var identity = base.CreateUserIdentityAsync(user);
            if (user.NecessarioAlterarSenha)
            {
                identity.Result.AddClaim(new Claim("necessarioalterarsenha", "sim"));
            }

            return identity;
            //return base.CreateUserIdentityAsync(user);
        }
    }
}