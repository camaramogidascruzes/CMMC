using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMMC.Domain.Interfaces.Services.Geral;
using CMMC.Domain.ViewModels;
using CMMC.UI.Web.Infrastructure.ActionResults;
using CMMC.UI.Web.Infrastructure.Controllers;
using Kendo.Mvc.UI;

namespace CMMC.UI.Web.Controllers
{
    public class GruposController : BasicController
    {
        private readonly IGrupoAppService _grupoappservice;

        public GruposController(IGrupoAppService grupoappservice)
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
    }
}