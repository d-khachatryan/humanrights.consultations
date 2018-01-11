using eLConsultation.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Controllers
{
    public class OralConsultationConsultantController : Controller
    {
        StoreContext db;
        OralConsultationConsultantService service;

        public OralConsultationConsultantController()
        {
            db = new StoreContext();
            service = new OralConsultationConsultantService(db);
        }

        public ActionResult OralConsultationConsultantSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectCosultants(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationConsultantCreate([DataSourceRequest] DataSourceRequest request, OralConsultationConsultantItem oralConsultationConsultantItem, string prmGUID)
        {
            if (oralConsultationConsultantItem != null && ModelState.IsValid)
            {
                oralConsultationConsultantItem.GUID = new Guid(prmGUID);
                oralConsultationConsultantItem = service.InsertConsultant(oralConsultationConsultantItem);
            }
            return Json(new[] { oralConsultationConsultantItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationConsultantUpdate([DataSourceRequest] DataSourceRequest request, OralConsultationConsultantItem oralConsultationConsultantItem)
        {
            if (oralConsultationConsultantItem != null && ModelState.IsValid)
            {
                oralConsultationConsultantItem = service.UpdateConsultant(oralConsultationConsultantItem);
            }

            return Json(new[] { oralConsultationConsultantItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationConsultantDelete([DataSourceRequest] DataSourceRequest request, OralConsultationConsultantItem oralConsultationConsultantItem)
        {
            if (oralConsultationConsultantItem != null)
            {
                oralConsultationConsultantItem = service.DeleteConsultant(oralConsultationConsultantItem);
            }
            return Json(new[] { oralConsultationConsultantItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult ConsultantList()
        {
            var list = service.ConsultantList().Select(c => new { Value = c.ConsultantID, Text = c.FirstName + " " + c.LastName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}