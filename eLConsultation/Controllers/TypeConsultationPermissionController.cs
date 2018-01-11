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
    public class TypeConsultationPermissionController : Controller
    {
        StoreContext db;
        TypeConsultationPermissionService service;

        public TypeConsultationPermissionController()
        {
            db = new StoreContext();
            service = new TypeConsultationPermissionService(db);
        }

        public ActionResult TypeConsultationPermissionSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectPermissions(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationPermissionCreate([DataSourceRequest] DataSourceRequest request, TypeConsultationPermissionItem typeConsultationPermissionItem, string prmGUID)
        {
            if (typeConsultationPermissionItem != null && ModelState.IsValid)
            {
                typeConsultationPermissionItem.GUID = new Guid(prmGUID);
                typeConsultationPermissionItem = service.InsertPermission(typeConsultationPermissionItem);
            }
            return Json(new[] { typeConsultationPermissionItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationPermissionUpdate([DataSourceRequest] DataSourceRequest request, TypeConsultationPermissionItem typeConsultationPermissionItem)
        {
            if (typeConsultationPermissionItem != null && ModelState.IsValid)
            {
                typeConsultationPermissionItem = service.UpdatePermission(typeConsultationPermissionItem);
            }

            return Json(new[] { typeConsultationPermissionItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationPermissionDelete([DataSourceRequest] DataSourceRequest request, TypeConsultationPermissionItem typeConsultationPermissionItem)
        {
            if (typeConsultationPermissionItem != null)
            {
                typeConsultationPermissionItem = service.DeletePermission(typeConsultationPermissionItem);
            }
            return Json(new[] { typeConsultationPermissionItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult UserList()
        {
            var list = service.UserList().Select(c => new { Value = c.Id, Text = c.UserName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}