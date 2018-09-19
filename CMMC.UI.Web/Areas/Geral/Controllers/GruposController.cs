using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.Services;
using CMMC.Domain.Interfaces.Services.Geral;
using CMMC.Domain.ViewModels;
using CMMC.UI.Web.Infrastructure.ActionResults;
using CMMC.UI.Web.Infrastructure.Controllers;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace CMMC.UI.Web.Areas.Geral.Controllers
{
    public class GruposController : BasicController
    {
        private readonly ICriacaoAlteracaoVMAppServiceBase<Grupo, GrupoViewModel> _grupoappservice;

        public GruposController(ICriacaoAlteracaoVMAppServiceBase<Grupo, GrupoViewModel> grupoappservice)
        {
            _grupoappservice = grupoappservice;
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View();
        }

        public StandardJsonResult Listar([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var grupos = _grupoappservice.LerTodosPagina(request.Page, request.PageSize, (q => q.OrderBy(gru => gru.Nome))).Result;
                return StandardJsonAllowGet(new DataSourceResult()
                {
                    Data = grupos.Itens.Select(gr => new GrupoViewModel(gr.Id, gr.Nome)),
                    Total = grupos.Total
                });
            }
            catch (Exception e)
            {
                return JsonErrorAllowGet(e.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Criar([DataSourceRequest] DataSourceRequest request, GrupoViewModel grupoVM)
        {
            if (grupoVM != null && ModelState.IsValid)
            {
                try
                {
                    grupoVM = _grupoappservice.Novo(grupoVM, User.Identity.Name).Result;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return StandardJson(new[] { grupoVM }.ToDataSourceResult(request, ModelState));
                }

            }

            return StandardJson(new[] { grupoVM }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Alterar([DataSourceRequest] DataSourceRequest request, GrupoViewModel grupoVM)
        {
            if (grupoVM != null && ModelState.IsValid)
            {
                try
                {
                    grupoVM = _grupoappservice.Alterar(grupoVM, User.Identity.Name).Result;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return StandardJson(new[] { grupoVM }.ToDataSourceResult(request, ModelState));
                }
            }
            return StandardJson(new[] { grupoVM }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, GrupoViewModel grupoVM)
        {
            if (grupoVM != null && ModelState.IsValid)
            {
                try
                {
                    _grupoappservice.Excluir(grupoVM, User.Identity.Name);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return StandardJson(new[] { grupoVM }.ToDataSourceResult(request, ModelState));
                }
            }
            return StandardJson(new[] { grupoVM }.ToDataSourceResult(request, ModelState));
        }

    }
}