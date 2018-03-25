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
    [Authorize(Roles = "administrator, writer")]
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

        public ActionResult FilterIssues([DataSourceRequest]DataSourceRequest request, string issueName)
        {
            ViewBag.ScreenWidth = Request.Browser.ScreenPixelsWidth;
            var issueSearch = new IssueSearch { IssueName = issueName};
            Session["issueSearch"] = issueSearch;
            DataSourceResult result = service.SearchIssueSetItems(issueSearch).ToDataSourceResult(request);
            return Json(result);
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

        public ActionResult Update(int issueID)
        {
            try
            {
                var item = service.GetIssueItemByID(issueID);
                InitializeViewBugs();
                return View("Template", item);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
                
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
                if(item.IssueCategoryID == 1)
                {
                    return RedirectToAction("Index", "Resident");
                }
                else 
                {
                    return RedirectToAction("Index", "Company");
                }
            }
            else
            {
                InitializeViewBugs();
                return View("Template", item);
            }
        }

        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, int issueID)
        {
            try
            {
                var item = service.DeleteIssue(issueID);
                if (item == false)
                {
                    return Json("No record in the database with the OralConsultationID provided", JsonRequestBehavior.AllowGet);
                }
                if (item == null)
                {
                    return Json(service.ServiceException.Message, JsonRequestBehavior.AllowGet);
                }
                return Json("DELETE_SUCCESS", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}