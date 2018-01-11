using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class ConsultantController : Controller
    {
        ConsultantService service;

        public ConsultantController()
        {
            service = new ConsultantService();
        }

        public JsonResult ConsultantList()
        {
            return Json(service.GetConsultants(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultantSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetConsultants().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultantCreate([DataSourceRequest] DataSourceRequest request, ConsultantItem consultantItem)
        {
            if (consultantItem != null && ModelState.IsValid)
            {
                service.CreateConsultant(consultantItem);
            }
            return Json(new[] { consultantItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultantUpdate([DataSourceRequest] DataSourceRequest request, ConsultantItem consultantItem)
        {
            if (consultantItem != null && ModelState.IsValid)
            {
                service.UpdateConsultant(consultantItem);
            }
            return Json(new[] { consultantItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultantDelete([DataSourceRequest] DataSourceRequest request, ConsultantItem consultantItem)
        {
            if (consultantItem != null)
            {
                service.DeleteConsultant(consultantItem);
            }
            return Json(new[] { consultantItem }.ToDataSourceResult(request, ModelState));
        }
    }
}