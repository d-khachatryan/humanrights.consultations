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
    public class OralConsultationRightController : Controller
    {
        StoreContext db;
        OralConsultationRightService service;

        public OralConsultationRightController()
        {
            db = new StoreContext();
            service = new OralConsultationRightService(db);
        }

        public ActionResult OralConsultationRightSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectRights(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationRightCreate([DataSourceRequest] DataSourceRequest request, OralConsultationRightItem oralConsultationRightItem, string prmGUID)
        {
            if (oralConsultationRightItem != null && ModelState.IsValid)
            {
                oralConsultationRightItem.GUID = new Guid(prmGUID);
                oralConsultationRightItem = service.InsertRight(oralConsultationRightItem);
            }
            return Json(new[] { oralConsultationRightItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationRightUpdate([DataSourceRequest] DataSourceRequest request, OralConsultationRightItem oralConsultationRightItem)
        {
            if (oralConsultationRightItem != null && ModelState.IsValid)
            {
                oralConsultationRightItem = service.UpdateRight(oralConsultationRightItem);
            }

            return Json(new[] { oralConsultationRightItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationRightDelete([DataSourceRequest] DataSourceRequest request, OralConsultationRightItem oralConsultationRightItem)
        {
            if (oralConsultationRightItem != null)
            {
                oralConsultationRightItem = service.DeleteRight(oralConsultationRightItem);
            }
            return Json(new[] { oralConsultationRightItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult HumanRightList()
        {
            var list = service.HumanRightList().Select(c => new { Value = c.HumanRightID, Text = c.HumanRightName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}