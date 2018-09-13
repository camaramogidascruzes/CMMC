using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CMMC.Domain.ViewModels;
using CMMC.Infraestrutura.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CMMC.UI.Web.Controllers
{
    public class SegurancaController : Controller
    {
        private readonly UserManager<IdentityUser, int> _userManager;
        private readonly RoleManager<IdentityRole, int> _roleManager;

        public SegurancaController(UserManager<IdentityUser, int> userManager, RoleManager<IdentityRole, int> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            _userManager.UserLockoutEnabledByDefault = true;
            _userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            _userManager.MaxFailedAccessAttemptsBeforeLockout = 5;

        }

        #region Helpers

        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion


        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.usuario);
                if (user != null)
                {

                    AuthenticationManager.SignOut();
                    var signInManager = new SignInManager(_userManager, AuthenticationManager);
                    var status = signInManager.PasswordSignIn<IdentityUser, int>(model.usuario, model.senha, false, true);
                    switch (status)
                    {
                        case SignInStatus.Success:
                            //log.Info("Acesso com sucesso - usuario: " + model.usuario + " - senha: " + model.senha);
                            return RedirectToLocal(returnUrl);
                        case SignInStatus.LockedOut:
                            //log.Warn("Usuário Bloqueado - usuario: " + model.usuario + " - senha: " + model.senha);
                            return View("Lockout");
                        case SignInStatus.Failure:
                        default:
                            //log.Warn("Usuário ou Senha inválidos - usuario: " + model.usuario + " - senha: " + model.senha);
                            ModelState.AddModelError("", "Usuário ou Senha inválidos !!!");
                            return View(model);
                    }

                    
                }
                else
                {
                    //log.Warn("Usuário ou Senha inválidos - usuario: " + model.usuario + " - senha: " + model.senha);
                    ModelState.AddModelError("", "Usuário ou Senha inválidos !!!");
                }
            }

            // If we got this far, something failed, redisplay form
            //log.Warn("Informações inválidas - usuario: " + model.usuario + " - senha: " + model.senha);
            return View(model);
        }
    }
}