using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class ConsultationResultController : Controller
    {
        ConsultationResultService service;

        public ConsultationResultController()
        {
            service = new ConsultationResultService();
        }

        public JsonResult ConsultationResultList()
        {
            return Json(service.GetConsultationResults(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultationResultSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetConsultationResults().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultationResultCreate([DataSourceRequest] DataSourceRequest request, ConsultationResultItem consultationResultItem)
        {
            if (consultationResultItem != null && ModelState.IsValid)
            {
                service.CreateConsultationResult(consultationResultItem);
            }
            return Json(new[] { consultationResultItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultationResultUpdate([DataSourceRequest] DataSourceRequest request, ConsultationResultItem consultationResultItem)
        {
            if (consultationResultItem != null && ModelState.IsValid)
            {
                service.UpdateConsultationResult(consultationResultItem);
            }
            return Json(new[] { consultationResultItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultationResultDelete([DataSourceRequest] DataSourceRequest request, ConsultationResultItem consultationResultItem)
        {
            if (consultationResultItem != null)
            {
                service.DeleteConsultationResult(consultationResultItem);
            }
            return Json(new[] { consultationResultItem }.ToDataSourceResult(request, ModelState));
        }
    }
}