using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class RegionController : Controller
    {
        RegionService service;

        public RegionController()
        {
            service = new RegionService();
        }

        public JsonResult RegionList()
        {
            return Json(service.GetRegions(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegionSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetRegions().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegionCreate([DataSourceRequest] DataSourceRequest request, RegionItem regionItem)
        {
            if (regionItem != null && ModelState.IsValid)
            {
                service.CreateRegion(regionItem);
            }
            return Json(new[] { regionItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegionUpdate([DataSourceRequest] DataSourceRequest request, RegionItem regionItem)
        {
            if (regionItem != null && ModelState.IsValid)
            {
                service.UpdateRegion(regionItem);
            }
            return Json(new[] { regionItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegionDelete([DataSourceRequest] DataSourceRequest request, RegionItem regionItem)
        {
            if (regionItem != null)
            {
                service.DeleteRegion(regionItem);
            }
            return Json(new[] { regionItem }.ToDataSourceResult(request, ModelState));
        }
    }
}