using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class TargetGroupController : Controller
    {
        TargetGroupService service;

        public TargetGroupController()
        {
            service = new TargetGroupService();
        }

        public JsonResult TargetGroupList()
        {
            return Json(service.GetTargetGroups(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TargetGroupSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetTargetGroups().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TargetGroupCreate([DataSourceRequest] DataSourceRequest request, TargetGroupItem targetGroupItem)
        {
            if (targetGroupItem != null && ModelState.IsValid)
            {
                service.CreateTargetGroup(targetGroupItem);
            }
            return Json(new[] { targetGroupItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TargetGroupUpdate([DataSourceRequest] DataSourceRequest request, TargetGroupItem targetGroupItem)
        {
            if (targetGroupItem != null && ModelState.IsValid)
            {
                service.UpdateTargetGroup(targetGroupItem);
            }
            return Json(new[] { targetGroupItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TargetGroupDelete([DataSourceRequest] DataSourceRequest request, TargetGroupItem targetGroupItem)
        {
            if (targetGroupItem != null)
            {
                service.DeleteTargetGroup(targetGroupItem);
            }
            return Json(new[] { targetGroupItem }.ToDataSourceResult(request, ModelState));
        }
    }
}