using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using CMMC.UI.Web.Infrastructure.ActionResults;

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


        [Obsolete("Do not use the standard Json helpers to return JSON data to the client.  Use either JsonSuccess or JsonError instead.")]
        protected JsonResult Json<T>(T data)
        {
            throw new InvalidOperationException("Do not use the standard Json helpers to return JSON data to the client.  Use either JsonSuccess or JsonError instead.");
        }

        protected StandardJsonResult JsonValidationError()
        {
            var result = new StandardJsonResult();

            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }
            return result;
        }

        protected StandardJsonResult JsonError(string errorMessage)
        {
            var result = new StandardJsonResult();

            result.AddError(errorMessage);

            return result;
        }

        protected StandardJsonResult<T> JsonSuccess<T>(T data)
        {
            return new StandardJsonResult<T> { Data = data };
        }

        protected StandardJsonResult StandardJson(object data)
        {
            return new StandardJsonResult() { Data = data, MaxJsonLength = 1000000 };
        }

        protected StandardJsonResult StandardJsonAllowGet(object data)
        {
            var json = StandardJson(data);
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.MaxJsonLength = 1000000;
            return json;
        }

        protected StandardJsonResult JsonErrorAllowGet(string errorMessage)
        {
            var json = new StandardJsonResult();
            json.AddError(errorMessage);
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.MaxJsonLength = 1000000;
            return json;
        }

    }
}