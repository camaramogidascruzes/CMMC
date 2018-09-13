using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using CMMC.Data.Context;
using CMMC.Data.Repositories.Geral;
using CMMC.Domain.Interfaces.Repositories.Geral;
using CMMC.Infraestrutura.Identity;
using Microsoft.AspNet.Identity;

namespace CMMC.Infraestrutura.IoC
{
    public class Bootstrap
    {
        public static void RegisterServices(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<GeralContext>(Lifestyle.Scoped);
            container.Register<UserManager<IdentityUser, int>>(Lifestyle.Scoped);
            container.Register<RoleManager<IdentityRole, int>>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IGrupoRepository, GrupoRepository>(Lifestyle.Scoped);
            container.Register<IUserStore<IdentityUser, int>, UserStore>(Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, int>, RoleStore>(Lifestyle.Scoped);
        }
    }
}
