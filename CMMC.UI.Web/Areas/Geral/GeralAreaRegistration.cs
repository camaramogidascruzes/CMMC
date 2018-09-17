using System.Web.Mvc;

namespace CMMC.UI.Web.Areas.Geral
{
    public class GeralAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Geral";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Geral_default",
                "Geral/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}