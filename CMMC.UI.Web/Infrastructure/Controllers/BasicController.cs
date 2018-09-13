using System;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.Web.Mvc;

namespace CMMC.UI.Web.Infrastructure.Controllers
{
    public class BasicController : Controller
    {
        public bool necessarioAlterarSenha
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var claim = ((ClaimsPrincipal) User).FindFirst("necessarioalterarsenha");
                    if (claim != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action)
            where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }
    }
}