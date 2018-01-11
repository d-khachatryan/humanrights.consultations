using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class ConsultationTypeController : Controller
    {
        ConsultationTypeService service;

        public ConsultationTypeController()
        {
            service = new ConsultationTypeService();
        }

        public JsonResult ConsultationTypeList()
        {
            return Json(service.GetConsultationTypes(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultationTypeSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetConsultationTypes().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultationTypeCreate([DataSourceRequest] DataSourceRequest request, ConsultationTypeItem consultationTypeItem)
        {
            if (consultationTypeItem != null && ModelState.IsValid)
            {
                service.CreateConsultationType(consultationTypeItem);
            }
            return Json(new[] { consultationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultationTypeUpdate([DataSourceRequest] DataSourceRequest request, ConsultationTypeItem consultationTypeItem)
        {
            if (consultationTypeItem != null && ModelState.IsValid)
            {
                service.UpdateConsultationType(consultationTypeItem);
            }
            return Json(new[] { consultationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsultationTypeDelete([DataSourceRequest] DataSourceRequest request, ConsultationTypeItem consultationTypeItem)
        {
            if (consultationTypeItem != null)
            {
                service.DeleteConsultationType(consultationTypeItem);
            }
            return Json(new[] { consultationTypeItem }.ToDataSourceResult(request, ModelState));
        }
    }
}