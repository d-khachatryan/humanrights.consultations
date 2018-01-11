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
    public class TypeConsultationInstanceController : Controller
    {
        StoreContext db;
        TypeConsultationInstanceService service;

        public TypeConsultationInstanceController()
        {
            db = new StoreContext();
            service = new TypeConsultationInstanceService(db);
        }

        public ActionResult TypeConsultationInstanceSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectCosultants(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationInstanceCreate([DataSourceRequest] DataSourceRequest request, TypeConsultationInstanceItem typeConsultationInstanceItem, string prmGUID)
        {
            if (typeConsultationInstanceItem != null && ModelState.IsValid)
            {
                typeConsultationInstanceItem.GUID = new Guid(prmGUID);
                typeConsultationInstanceItem = service.InsertInstance(typeConsultationInstanceItem);
            }
            return Json(new[] { typeConsultationInstanceItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationInstanceUpdate([DataSourceRequest] DataSourceRequest request, TypeConsultationInstanceItem typeConsultationInstanceItem)
        {
            if (typeConsultationInstanceItem != null && ModelState.IsValid)
            {
                typeConsultationInstanceItem = service.UpdateInstance(typeConsultationInstanceItem);
            }

            return Json(new[] { typeConsultationInstanceItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationInstanceDelete([DataSourceRequest] DataSourceRequest request, TypeConsultationInstanceItem typeConsultationInstanceItem)
        {
            if (typeConsultationInstanceItem != null)
            {
                typeConsultationInstanceItem = service.DeleteInstance(typeConsultationInstanceItem);
            }
            return Json(new[] { typeConsultationInstanceItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OrganizationList()
        {
            var list = service.OrganizationList().Select(c => new { Value = c.OrganizationID, Text = c.OrganizationName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}