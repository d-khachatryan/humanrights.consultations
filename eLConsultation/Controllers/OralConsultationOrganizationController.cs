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
    [Authorize(Roles = "administrator, writer")]
    public class OralConsultationOrganizationController : Controller
    {
        StoreContext db;
        OralConsultationOrganizationService service;

        public OralConsultationOrganizationController()
        {
            db = new StoreContext();
            service = new OralConsultationOrganizationService(db);
        }

        [Authorize(Roles = "administrator, writer, reader")]
        public ActionResult OralConsultationOrganizationSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectOrganizations(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationOrganizationCreate([DataSourceRequest] DataSourceRequest request, OralConsultationOrganizationItem oralConsultationOrganizationItem, string prmGUID)
        {
            if (oralConsultationOrganizationItem != null && ModelState.IsValid)
            {
                oralConsultationOrganizationItem.GUID = new Guid(prmGUID);
                oralConsultationOrganizationItem = service.InsertOrganization(oralConsultationOrganizationItem);
            }
            return Json(new[] { oralConsultationOrganizationItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationOrganizationUpdate([DataSourceRequest] DataSourceRequest request, OralConsultationOrganizationItem oralConsultationOrganizationItem)
        {
            if (oralConsultationOrganizationItem != null && ModelState.IsValid)
            {
                oralConsultationOrganizationItem = service.UpdateOrganization(oralConsultationOrganizationItem);
            }

            return Json(new[] { oralConsultationOrganizationItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationOrganizationDelete([DataSourceRequest] DataSourceRequest request, OralConsultationOrganizationItem oralConsultationOrganizationItem)
        {
            if (oralConsultationOrganizationItem != null)
            {
                oralConsultationOrganizationItem = service.DeleteOrganization(oralConsultationOrganizationItem);
            }
            return Json(new[] { oralConsultationOrganizationItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OrganizationList()
        {
            var list = service.OrganizationList().Select(c => new { Value = c.OrganizationID, Text = c.OrganizationName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}