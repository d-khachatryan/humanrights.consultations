using System;
using System.Web;
using System.Web.Mvc;
using eLConsultation.Data;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace eLConsultation.Controllers
{
    public class IssueController : Controller
    {
        StoreContext db;
        IssueService service;

        public IssueController()
        {
            db = new StoreContext();
            service = new IssueService();
        }

        private void InitializeViewBugs()
        {
            ViewBag.vbIssueTypes = service.GetIssueTypeDropDownItems();
            ViewBag.vbIssueCategorys = service.GetIssueCategoryDropDownItems();
        }

        public ActionResult GetIssuesSetItemsByResidentID([DataSourceRequest] DataSourceRequest request, int residentID)
        {
            DataSourceResult result = service.GetIssueSetItemsByResidentID(residentID).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult GetIssuesSetItemsByCompanyID([DataSourceRequest] DataSourceRequest request, int companyID)
        {
            DataSourceResult result = service.GetIssueSetItemsByCompanyID(companyID).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult InitializeResidentIssue(int residentID)
        {
            InitializeViewBugs();
            var item = service.GetIssueItemByResidentID(residentID);
            return View("Template", item);
        }

        public ActionResult InitializeCompanyIssue(int companyID)
        {
            InitializeViewBugs();
            var item = service.GetIssueItemByCompanyID(companyID);
            return View("Template", item);
        }

        [HttpPost]
        public ActionResult SaveIssue(IssueItem item)
        {
            if (ModelState.IsValid)
            {
                IssueItem resultItem = null;
                switch (item.InitializationType)
                {
                    case InitializationTypes.Insert:
                        resultItem = service.SaveIssue(item);
                        break;
                    case InitializationTypes.Update:
                        resultItem = service.SaveIssue(item);
                        break;
                }

                //if (resultItem != null)
                //{
                //    switch (item.ConsultationType)
                //    {
                //        case ConsultationTypes.OralConsultation:
                //            return RedirectToAction("Template", "OralConsultation", new { issueID = resultItem.IssueID });
                //        case ConsultationTypes.TypeConsultation:
                //            return RedirectToAction("Template", "TypeConsultation", new { issueID = resultItem.IssueID });
                //    }

                //}
                //else
                //{
                //    InitializeViewBugs();
                //    ModelState.AddModelError("error", "Error occured");
                //    return View("Template", item);
                //}
                return View("Template", item);
            }
            else
            {
                InitializeViewBugs();
                return View("Template", item);
            }
        }

        //public ActionResult Delete([DataSourceRequest]DataSourceRequest request, int oralConsultationID)
        //{
        //    try
        //    {
        //        var item = service.Delete(oralConsultationID);
        //        if (item == false)
        //        {
        //            return Json("No record in the database with the OralConsultationID provided", JsonRequestBehavior.AllowGet);
        //        }
        //        if (item == null)
        //        {
        //            return Json(service.serviceException.Message, JsonRequestBehavior.AllowGet);
        //        }
        //        return Json("DELETE_SUCCESS", JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}