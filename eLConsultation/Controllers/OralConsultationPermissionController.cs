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
    public class OralConsultationPermissionController : Controller
    {
        StoreContext db;
        OralConsultationPermissionService service;

        public OralConsultationPermissionController()
        {
            db = new StoreContext();
            service = new OralConsultationPermissionService(db);
        }

        public ActionResult OralConsultationPermissionSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectPermissions(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationPermissionCreate([DataSourceRequest] DataSourceRequest request, OralConsultationPermissionItem oralConsultationPermissionItem, string prmGUID)
        {
            if (oralConsultationPermissionItem != null && ModelState.IsValid)
            {
                oralConsultationPermissionItem.GUID = new Guid(prmGUID);
                oralConsultationPermissionItem = service.InsertPermission(oralConsultationPermissionItem);
            }
            return Json(new[] { oralConsultationPermissionItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationPermissionUpdate([DataSourceRequest] DataSourceRequest request, OralConsultationPermissionItem oralConsultationPermissionItem)
        {
            if (oralConsultationPermissionItem != null && ModelState.IsValid)
            {
                oralConsultationPermissionItem = service.UpdatePermission(oralConsultationPermissionItem);
            }

            return Json(new[] { oralConsultationPermissionItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OralConsultationPermissionDelete([DataSourceRequest] DataSourceRequest request, OralConsultationPermissionItem oralConsultationPermissionItem)
        {
            if (oralConsultationPermissionItem != null)
            {
                oralConsultationPermissionItem = service.DeletePermission(oralConsultationPermissionItem);
            }
            return Json(new[] { oralConsultationPermissionItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult UserList()
        {
            var list = service.UserList().Select(c => new { Value = c.Id, Text = c.UserName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}