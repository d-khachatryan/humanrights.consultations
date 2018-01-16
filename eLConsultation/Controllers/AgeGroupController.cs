using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    [Authorize(Roles = "administrator")]
    public class AgeGroupController : Controller
    {
        AgeGroupService service;

        public AgeGroupController()
        {
            service = new AgeGroupService(HttpContext);
        }

        public JsonResult AgeGroupList()
        {
            return Json(service.GetAgeGroups(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgeGroupSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAgeGroups().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AgeGroupCreate([DataSourceRequest] DataSourceRequest request, AgeGroupItem ageGroupItem)
        {
            if (ageGroupItem != null && ModelState.IsValid)
            {
                service.CreateAgeGroup(ageGroupItem);
            }
            return Json(new[] { ageGroupItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AgeGroupUpdate([DataSourceRequest] DataSourceRequest request, AgeGroupItem ageGroupItem)
        {
            if (ageGroupItem != null && ModelState.IsValid)
            {
                service.UpdateAgeGroup(ageGroupItem);
            }
            return Json(new[] { ageGroupItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AgeGroupDelete([DataSourceRequest] DataSourceRequest request, AgeGroupItem ageGroupItem)
        {
            if (ageGroupItem != null)
            {
                service.DeleteAgeGroup(ageGroupItem);
            }
            return Json(new[] { ageGroupItem }.ToDataSourceResult(request, ModelState));
        }
    }
}