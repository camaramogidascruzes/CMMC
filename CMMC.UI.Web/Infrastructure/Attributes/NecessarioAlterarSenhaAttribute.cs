using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMMC.UI.Web.Infrastructure.Attributes
{
    public class NecessarioAlterarSenhaAttribute : ActionFilterAttribute
    {
        private string redirectAction;
        private string redirectController;

        public NecessarioAlterarSenhaAttribute(string redirectController, string redirectAction)
        {
            this.redirectController = redirectController;
            this.redirectAction = redirectAction;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var claim = ((ClaimsPrincipal) HttpContext.Current.User).FindFirst("necessarioalterarsenha");
                if (claim != null)
                {
                    string routeAction = filterContext.RouteData.Values["action"].ToString();
                    string routeController = filterContext.RouteData.Values["controller"].ToString();
                    if (routeAction != null && routeController != null && routeAction != this.redirectAction && routeController != redirectController)
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary
                            {
                                { "controller", this.redirectController },
                                { "action", this.redirectAction }
                            });
                    }

                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}