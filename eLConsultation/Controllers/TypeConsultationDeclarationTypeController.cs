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
    public class TypeConsultationDeclarationTypeController : Controller
    {
        StoreContext db;
        TypeConsultationDeclarationTypeService service;

        public TypeConsultationDeclarationTypeController()
        {
            db = new StoreContext();
            service = new TypeConsultationDeclarationTypeService();
        }

        public ActionResult TypeConsultationDeclarationTypeSelect([DataSourceRequest] DataSourceRequest request, string prmGUID)
        {
            var q = service.SelectDeclarationTypes(prmGUID);
            return Json(q.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationDeclarationTypeCreate([DataSourceRequest] DataSourceRequest request, TypeConsultationDeclarationTypeItem typeConsultationDeclarationTypeItem, string prmGUID)
        {
            if (typeConsultationDeclarationTypeItem != null && ModelState.IsValid)
            {
                typeConsultationDeclarationTypeItem.GUID = new Guid(prmGUID);
                typeConsultationDeclarationTypeItem = service.InsertDeclarationType(typeConsultationDeclarationTypeItem);
            }
            return Json(new[] { typeConsultationDeclarationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationDeclarationTypeUpdate([DataSourceRequest] DataSourceRequest request, TypeConsultationDeclarationTypeItem typeConsultationDeclarationTypeItem)
        {
            if (typeConsultationDeclarationTypeItem != null && ModelState.IsValid)
            {
                typeConsultationDeclarationTypeItem = service.UpdateDeclarationType(typeConsultationDeclarationTypeItem);
            }

            return Json(new[] { typeConsultationDeclarationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TypeConsultationDeclarationTypeDelete([DataSourceRequest] DataSourceRequest request, TypeConsultationDeclarationTypeItem typeConsultationDeclarationTypeItem)
        {
            if (typeConsultationDeclarationTypeItem != null)
            {
                typeConsultationDeclarationTypeItem = service.DeleteDeclarationType(typeConsultationDeclarationTypeItem);
            }
            return Json(new[] { typeConsultationDeclarationTypeItem }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult DeclarationTypeList()
        {
            var list = service.GetDeclarationTypeDropDownItems();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OrganizationList()
        {
            var list = service.GetOrganizationDropDownItems();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ResponseTypeList()
        {
            var list = service.GetResponseTypeDropDownItems();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ResponseContentList()
        {
            var list = service.GetResponseContentDropDownItems();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ResponseQuantityList()
        {
            var list = service.GetResponseQuantityDropDownItems();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}