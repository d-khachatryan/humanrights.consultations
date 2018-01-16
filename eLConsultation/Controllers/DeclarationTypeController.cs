using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    [Authorize(Roles = "administrator")]
    public class DeclarationTypeController : Controller
    {
        DeclarationTypeService service;

        public DeclarationTypeController()
        {
            service = new DeclarationTypeService();
        }

        public JsonResult DeclarationTypeList()
        {
            return Json(service.GetDeclarationTypes(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeclarationTypeSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetDeclarationTypes().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeclarationTypeCreate([DataSourceRequest] DataSourceRequest request, DeclarationTypeItem declarationTypeItem)
        {
            if (declarationTypeItem != null && ModelState.IsValid)
            {
                service.CreateDeclarationType(declarationTypeItem);
            }
            return Json(new[] { declarationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeclarationTypeUpdate([DataSourceRequest] DataSourceRequest request, DeclarationTypeItem declarationTypeItem)
        {
            if (declarationTypeItem != null && ModelState.IsValid)
            {
                service.UpdateDeclarationType(declarationTypeItem);
            }
            return Json(new[] { declarationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeclarationTypeDelete([DataSourceRequest] DataSourceRequest request, DeclarationTypeItem declarationTypeItem)
        {
            if (declarationTypeItem != null)
            {
                service.DeleteDeclarationType(declarationTypeItem);
            }
            return Json(new[] { declarationTypeItem }.ToDataSourceResult(request, ModelState));
        }
    }
}