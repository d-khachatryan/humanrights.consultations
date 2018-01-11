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
    public class TypeConsultationRecipientController : Controller
    {
        StoreContext db;
        TypeConsultationRecipientService service;

        public TypeConsultationRecipientController()
        {
            db = new StoreContext();
            service = new TypeConsultationRecipientService(db);
        }

        public ActionResult TypeConsultationRecipientSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectCosultants(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationRecipientCreate([DataSourceRequest] DataSourceRequest request, TypeConsultationRecipientItem typeConsultationRecipientItem, string prmGUID)
        {
            if (typeConsultationRecipientItem != null && ModelState.IsValid)
            {
                typeConsultationRecipientItem.GUID = new Guid(prmGUID);
                typeConsultationRecipientItem = service.InsertRecipient(typeConsultationRecipientItem);
            }
            return Json(new[] { typeConsultationRecipientItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationRecipientUpdate([DataSourceRequest] DataSourceRequest request, TypeConsultationRecipientItem typeConsultationRecipientItem)
        {
            if (typeConsultationRecipientItem != null && ModelState.IsValid)
            {
                typeConsultationRecipientItem = service.UpdateRecipient(typeConsultationRecipientItem);
            }

            return Json(new[] { typeConsultationRecipientItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationRecipientDelete([DataSourceRequest] DataSourceRequest request, TypeConsultationRecipientItem typeConsultationRecipientItem)
        {
            if (typeConsultationRecipientItem != null)
            {
                typeConsultationRecipientItem = service.DeleteRecipient(typeConsultationRecipientItem);
            }
            return Json(new[] { typeConsultationRecipientItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OrganizationList()
        {
            var list = service.OrganizationList().Select(c => new { Value = c.OrganizationID, Text = c.OrganizationName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}