using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class InvocationTypeController : Controller
    {
        InvocationTypeService service;

        public InvocationTypeController()
        {
            service = new InvocationTypeService();
        }

        public JsonResult InvocationTypeList()
        {
            return Json(service.GetInvocationTypes(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InvocationTypeSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetInvocationTypes().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InvocationTypeCreate([DataSourceRequest] DataSourceRequest request, InvocationTypeItem invocationTypeItem)
        {
            if (invocationTypeItem != null && ModelState.IsValid)
            {
                service.CreateInvocationType(invocationTypeItem);
            }
            return Json(new[] { invocationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InvocationTypeUpdate([DataSourceRequest] DataSourceRequest request, InvocationTypeItem invocationTypeItem)
        {
            if (invocationTypeItem != null && ModelState.IsValid)
            {
                service.UpdateInvocationType(invocationTypeItem);
            }
            return Json(new[] { invocationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InvocationTypeDelete([DataSourceRequest] DataSourceRequest request, InvocationTypeItem invocationTypeItem)
        {
            if (invocationTypeItem != null)
            {
                service.DeleteInvocationType(invocationTypeItem);
            }
            return Json(new[] { invocationTypeItem }.ToDataSourceResult(request, ModelState));
        }
    }
}