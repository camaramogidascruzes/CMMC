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
    }
}