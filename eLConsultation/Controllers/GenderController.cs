using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    [Authorize(Roles = "administrator")]
    public class GenderController : Controller
    {
        GenderService service;

        public GenderController()
        {
            service = new GenderService();
        }

        public JsonResult GenderList()
        {
            return Json(service.GetGenders(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenderSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetGenders().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GenderCreate([DataSourceRequest] DataSourceRequest request, GenderItem genderItem)
        {
            if (genderItem != null && ModelState.IsValid)
            {
                service.CreateGender(genderItem);
            }
            return Json(new[] { genderItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GenderUpdate([DataSourceRequest] DataSourceRequest request, GenderItem genderItem)
        {
            if (genderItem != null && ModelState.IsValid)
            {
                service.UpdateGender(genderItem);
            }
            return Json(new[] { genderItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GenderDelete([DataSourceRequest] DataSourceRequest request, GenderItem genderItem)
        {
            if (genderItem != null)
            {
                service.DeleteGender(genderItem);
            }
            return Json(new[] { genderItem }.ToDataSourceResult(request, ModelState));
        }
    }
}