using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    [Authorize(Roles = "administrator")]
    public class ProcessStatusController : Controller
    {
        ProcessStatusService service;

        public ProcessStatusController()
        {
            service = new ProcessStatusService();
        }

        public JsonResult ProcessStatusList()
        {
            return Json(service.GetProcessStatuss(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProcessStatusSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetProcessStatuss().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProcessStatusCreate([DataSourceRequest] DataSourceRequest request, ProcessStatusItem processStatusItem)
        {
            if (processStatusItem != null && ModelState.IsValid)
            {
                service.CreateProcessStatus(processStatusItem);
            }
            return Json(new[] { processStatusItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProcessStatusUpdate([DataSourceRequest] DataSourceRequest request, ProcessStatusItem processStatusItem)
        {
            if (processStatusItem != null && ModelState.IsValid)
            {
                service.UpdateProcessStatus(processStatusItem);
            }
            return Json(new[] { processStatusItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProcessStatusDelete([DataSourceRequest] DataSourceRequest request, ProcessStatusItem processStatusItem)
        {
            if (processStatusItem != null)
            {
                service.DeleteProcessStatus(processStatusItem);
            }
            return Json(new[] { processStatusItem }.ToDataSourceResult(request, ModelState));
        }
    }
}