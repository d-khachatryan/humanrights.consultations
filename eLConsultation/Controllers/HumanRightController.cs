using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class HumanRightController : Controller
    {
        HumanRightService service;

        public HumanRightController()
        {
            service = new HumanRightService();
        }

        public JsonResult HumanRightList()
        {
            return Json(service.GetHumanRights(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HumanRightSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetHumanRights().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HumanRightCreate([DataSourceRequest] DataSourceRequest request, HumanRightItem humanRightItem)
        {
            if (humanRightItem != null && ModelState.IsValid)
            {
                service.CreateHumanRight(humanRightItem);
            }
            return Json(new[] { humanRightItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HumanRightUpdate([DataSourceRequest] DataSourceRequest request, HumanRightItem humanRightItem)
        {
            if (humanRightItem != null && ModelState.IsValid)
            {
                service.UpdateHumanRight(humanRightItem);
            }
            return Json(new[] { humanRightItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HumanRightDelete([DataSourceRequest] DataSourceRequest request, HumanRightItem humanRightItem)
        {
            if (humanRightItem != null)
            {
                service.DeleteHumanRight(humanRightItem);
            }
            return Json(new[] { humanRightItem }.ToDataSourceResult(request, ModelState));
        }
    }
}