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
    public class TypeConsultationRightController : Controller
    {
        StoreContext db;
        TypeConsultationRightService service;

        public TypeConsultationRightController()
        {
            db = new StoreContext();
            service = new TypeConsultationRightService(db);
        }

        public ActionResult TypeConsultationRightSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectCosultants(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationRightCreate([DataSourceRequest] DataSourceRequest request, TypeConsultationRightItem typeConsultationRightItem, string prmGUID)
        {
            if (typeConsultationRightItem != null && ModelState.IsValid)
            {
                typeConsultationRightItem.GUID = new Guid(prmGUID);
                typeConsultationRightItem = service.InsertRight(typeConsultationRightItem);
            }
            return Json(new[] { typeConsultationRightItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationRightUpdate([DataSourceRequest] DataSourceRequest request, TypeConsultationRightItem typeConsultationRightItem)
        {
            if (typeConsultationRightItem != null && ModelState.IsValid)
            {
                typeConsultationRightItem = service.UpdateRight(typeConsultationRightItem);
            }

            return Json(new[] { typeConsultationRightItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationRightDelete([DataSourceRequest] DataSourceRequest request, TypeConsultationRightItem typeConsultationRightItem)
        {
            if (typeConsultationRightItem != null)
            {
                typeConsultationRightItem = service.DeleteRight(typeConsultationRightItem);
            }
            return Json(new[] { typeConsultationRightItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult HumanRightList()
        {
            var list = service.HumanRightList().Select(c => new { Value = c.HumanRightID, Text = c.HumanRightName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}