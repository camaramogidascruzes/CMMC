using System.Web;
using System.Web.Mvc;
using CMMC.UI.Web.Infrastructure.Attributes;

namespace CMMC.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new NecessarioAlterarSenhaAttribute("Seguranca", "AlteraSenha"));
        }
    }
}
