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
    public class TypeConsultationConsultantController : Controller
    {
        StoreContext db;
        TypeConsultationConsultantService service;

        public TypeConsultationConsultantController()
        {
            db = new StoreContext();
            service = new TypeConsultationConsultantService(db);
        }

        public ActionResult TypeConsultationConsultantSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectCosultants(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationConsultantCreate([DataSourceRequest] DataSourceRequest request, TypeConsultationConsultantItem typeConsultationConsultantItem, string prmGUID)
        {
            if (typeConsultationConsultantItem != null && ModelState.IsValid)
            {
                typeConsultationConsultantItem.GUID = new Guid(prmGUID);
                typeConsultationConsultantItem = service.InsertConsultant(typeConsultationConsultantItem);
            }
            return Json(new[] { typeConsultationConsultantItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationConsultantUpdate([DataSourceRequest] DataSourceRequest request, TypeConsultationConsultantItem typeConsultationConsultantItem)
        {
            if (typeConsultationConsultantItem != null && ModelState.IsValid)
            {
                typeConsultationConsultantItem = service.UpdateConsultant(typeConsultationConsultantItem);
            }

            return Json(new[] { typeConsultationConsultantItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationConsultantDelete([DataSourceRequest] DataSourceRequest request, TypeConsultationConsultantItem typeConsultationConsultantItem)
        {
            if (typeConsultationConsultantItem != null)
            {
                typeConsultationConsultantItem = service.DeleteConsultant(typeConsultationConsultantItem);
            }
            return Json(new[] { typeConsultationConsultantItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult ConsultantList()
        {
            var list = service.ConsultantList().Select(c => new { Value = c.ConsultantID, Text = c.FirstName + " " + c.LastName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}