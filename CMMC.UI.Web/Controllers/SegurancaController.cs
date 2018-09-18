using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CMMC.Domain.Interfaces.Services.Geral;
using CMMC.Domain.ViewModels;
using CMMC.Infraestrutura.Identity;
using CMMC.UI.Web.Infrastructure.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CMMC.UI.Web.Infrastructure.ActionResults;

namespace CMMC.UI.Web.Controllers
{
    public class SegurancaController : BasicController
    {
        private readonly UserManager<IdentityUser, int> _userManager;
        private readonly RoleManager<IdentityRole, int> _roleManager;
        private readonly IUsuarioAppService _usuarioappservice;

        public SegurancaController(UserManager<IdentityUser, int> userManager, RoleManager<IdentityRole, int> roleManager, IUsuarioAppService usuarioappservice)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _usuarioappservice = usuarioappservice;


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

        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult AlteraSenha()
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    var usuario = _userManager.FindByName(User.Identity.Name);
                    //if (usuario == null)
                    //{
                    //    return RedirectToAction<UsuarioController>(c => c.Index()).WithError("Erro ao ler dados do Usuário. Favor entrar em contato com o Setor de Informática !!!");
                    //}
                    return View(new AlteraSenhaViewModel(usuario.Id, usuario.Login));
                }
                catch (Exception e)
                {
                    //return RedirectToAction<UsuarioController>(c => c.Index()).WithError("Erro ao ler dados do Usuário. Favor entrar em contato com o Setor de Informática !!!");
                }
            }

            return RedirectToAction<HomeController>(c => c.Index()); //.WithError("ID inválido");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlteraSenha(AlteraSenhaViewModel usr)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var identityResult = _userManager.ChangePassword(usr.usuarioId, usr.senhaantiga, usr.senha);
                        if (identityResult.Succeeded)
                        {
                            //log.Info("Usuario alterou sua senha - " + usr.senhaantiga + " - " + usr.senha);

                            if (this.necessarioAlterarSenha)
                            {
                                if (_usuarioappservice.AlteraNecessarioAlterarSenha(usr.usuarioId, false).IsCompleted)
                                {
                                    return RedirectToAction("Logoff");
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Não foi possível alterar sua senha !!!");
                                    return View(usr);
                                }
                            }

                            return RedirectToAction<HomeController>(c => c.Index());//.WithSuccess("Senha alterada com sucesso !!!");
                        }
                        else
                        {
                            foreach (var error in identityResult.Errors)
                            {
                                ModelState.AddModelError("", error);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                        return View(usr);
                    }
                }
                return View(usr);
            }
            return RedirectToAction<HomeController>(c => c.Index());
        }


        [Authorize(Roles = "Administrador")]
        public ActionResult Usuarios()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Grupos()
        {
            return View();
        }

        //public StandardJsonResult ListarTodosGrupos()
        //{
        //    try
        //    {
        //        return StandardJsonAllowGet(_usuarioappservice.LerTodos(idGabinete.Value).Select(g => new { id = g.id, nome = g.nome, descricao = g.descricao }));
        //    }
        //    catch (Exception e)
        //    {
        //        return JsonErrorAllowGet(e.Message);
        //    }
        //}

    }
}