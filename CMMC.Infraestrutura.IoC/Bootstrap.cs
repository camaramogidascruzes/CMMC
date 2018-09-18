using CMMC.Applications.Services.Geral;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using CMMC.Data.Context;
using CMMC.Data.Repositories;
using CMMC.Domain.Interfaces.Repositories;
using CMMC.Domain.Interfaces.Services.Geral;
using CMMC.Infraestrutura.Identity;
using Microsoft.AspNet.Identity;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Infraestrutura.IoC
{
    public class Bootstrap
    {
        public static void RegisterServices(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<GeralContext>(Lifestyle.Scoped);
            // Procura no assembly implementações de IRepositoryBase<>
            container.Register<UserManager<IdentityUser, int>>(Lifestyle.Scoped);
            container.Register<RoleManager<IdentityRole, int>>(Lifestyle.Scoped);
            container.Register<IRepositoryBase<Usuario>>(() => new RepositoryBase<Usuario>(new GeralContext()), Lifestyle.Scoped);
            container.Register<IRepositoryBase<Grupo>>(() => new RepositoryBase<Grupo>(new GeralContext()), Lifestyle.Scoped);
            container.Register<IUsuarioAppService,UsuarioAppService >(Lifestyle.Scoped);
            container.Register<IGrupoAppService, GrupoAppService>(Lifestyle.Scoped);
            container.Register<IUserStore<IdentityUser, int>, UserStore>(Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, int>, RoleStore>(Lifestyle.Scoped);
        }
    }
}
