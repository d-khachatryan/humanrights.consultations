using eLConsultation.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator,writer")]
    public class TypeConsultationController : BaseController
    {
        private TypeConsultationService typeConsultationService;
        private ResidentService residentService;
        private CompanyService companyService;
        private IssueService issueService;

        public TypeConsultationController()
            : base()
        {
            typeConsultationService = new TypeConsultationService();
            residentService = new ResidentService();
            issueService = new IssueService();
            companyService = new CompanyService();
        }

        public ActionResult Index()
        {
            var typeConsultationSearch = new TypeConsultationSearch();
            if (Session["typeConsultationSearch"] != null)
            {
                typeConsultationSearch = (TypeConsultationSearch)Session["typeConsultationSearch"];
            }
            if (Request.Browser.IsMobileDevice)
            {
                return View("MobileIndex", typeConsultationSearch);
            }
            return View(typeConsultationSearch);
        }

        public ActionResult FilterTypeConsultations([DataSourceRequest]DataSourceRequest request, /*string firstName, string lastName,*/ DateTime? typeconsultationdate, int? typeconsultationid)
        {
            var typeConsultationSearch = new TypeConsultationSearch { /*FirstName = firstName, LastName = lastName,*/ TypeConsultationDate = typeconsultationdate, TypeConsultationID = typeconsultationid };
            Session["typeConsultationSearch"] = typeConsultationSearch;
            DataSourceResult result = typeConsultationService.FilterTypeConsultations(typeConsultationSearch).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult ResidentDispatcher()
        {
            var residentSearch = new ResidentSearch();
            return View("ResidentDispatcher", residentSearch);
        }

        public ActionResult IssueDispatcher()
        {
            var issueSearch = new IssueSearch();
            return View("IssueDispatcher", issueSearch);
        }

        public ActionResult CompanyDispatcher()
        {
            var companySearch = new CompanySearch();
            return View("CompanyDispatcher", companySearch);
        }

        public ActionResult Resident(int? residentID = null)
        {
            var item = residentService.GetResidentItem();
            InitializeResidentViewBugs();
            return View("Resident", item);
        }

        public ActionResult Company(int? companyID = null)
        {
            var item = companyService.GetCompanyItem();
            return View("Company", item);
        }

        public ActionResult ResidentIssue(int residentID)
        {
            var item = issueService.GetIssueItemByResidentID(residentID);
            InitializeIssueViewBugs();
            return View("Issue", item);
        }

        public ActionResult AnonymousIssue()
        {
            var item = issueService.GetAnonymousIssueItem();
            InitializeIssueViewBugs();
            return View("AnonymousIssue", item);
        }

        public ActionResult CompanyIssue(int companyID)
        {
            var item = issueService.GetIssueItemByCompanyID(companyID);
            InitializeIssueViewBugs();
            return View("Issue", item);
        }

        public ActionResult InitTypeConsultation(int issueID)
        {
            InitializeTypeConsultationViewBugs();
            var issueItem = issueService.GetIssueItemByID(issueID);
            InitializeTypeConsultationIssueViewBugs(issueItem);
            var item = typeConsultationService.GetTypeConsultationByIssueID(issueID);
            return View("TypeConsultation", item);
        }

        public ActionResult UpdateTypeConsultation(int typeConsultationID)
        {
            InitializeTypeConsultationViewBugs();
            var issueItem = typeConsultationService.GetIssueItemByID(typeConsultationID);
            InitializeTypeConsultationIssueViewBugs(issueItem);
            var item = typeConsultationService.GetTypeConsultationItemByID(typeConsultationID);
            return View("TypeConsultation", item);
        }

        [HttpPost]
        public ActionResult SaveResident(ResidentItem item)
        {
            if (ModelState.IsValid)
            {
                item = residentService.SaveResident(item);
                InitializeIssueViewBugs();
                return RedirectToAction("ResidentIssue", new { residentID = item.ResidentID });
            }
            else
            {
                InitializeResidentViewBugs();
                return View("Resident", item);
            }
        }

        [HttpPost]
        public ActionResult SaveCompany(CompanyItem item)
        {
            if (ModelState.IsValid)
            {
                item = companyService.SaveCompany(item);
                InitializeIssueViewBugs();
                return RedirectToAction("CompanyIssue", new { companyID = item.CompanyID });
            }
            else
            {
                InitializeResidentViewBugs();
                return View("Company", item);
            }
        }

        [HttpPost]
        public ActionResult SaveIssue(IssueItem item)
        {
            if (ModelState.IsValid)
            {
                item = issueService.SaveIssue(item);
                InitializeTypeConsultationViewBugs();
                InitializeTypeConsultationIssueViewBugs(item);
                return RedirectToAction("InitTypeConsultation", new { issueID = item.IssueID });
            }
            else
            {
                InitializeIssueViewBugs();
                return View("Issue", item);
            }
        }

        [HttpPost]
        public ActionResult SaveAnonymousIssue(AnonymousIssueItem item)
        {
            if (ModelState.IsValid)
            {
                item = issueService.SaveAnonymousIssue(item);
                InitializeTypeConsultationViewBugs();
                InitializeAnonymousIssueViewBugs(item);
                return RedirectToAction("InitTypeConsultation", new { issueID = item.IssueID });
            }
            else
            {
                InitializeIssueViewBugs();
                return View("AnonymousIssue", item);
            }
        }

        [HttpPost]
        public ActionResult SaveTypeConsultation(TypeConsultationItem item)
        {
            if (ModelState.IsValid)
            {
                item.UserID = signedUserID;

                TypeConsultationItem resultItem = typeConsultationService.SaveTypeConsultation(item);

                if (resultItem != null)
                {
                    return RedirectToAction("Index", "TypeConsultation");
                }
                else
                {
                    InitializeTypeConsultationViewBugs();
                    ModelState.AddModelError("error", typeConsultationService.ServiceException.Message);
                    return View("TypeConsultation", item);
                }
            }
            else
            {
                InitializeTypeConsultationViewBugs();
                return View("TypeConsultation", item);
            }
        }

        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, int typeConsultationID)
        {
            try
            {
                var item = typeConsultationService.DeleteTypeConsultation(typeConsultationID);
                if (item == false)
                {
                    return Json("No record in the database with the TypeConsultationID provided", JsonRequestBehavior.AllowGet);
                }
                if (item == null)
                {
                    return Json(typeConsultationService.ServiceException.Message, JsonRequestBehavior.AllowGet);
                }
                return Json("DELETE_SUCCESS", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int typeConsultationID)
        {
            TypeConsultationDetail detail = typeConsultationService.GetTypeConsultationDetail(typeConsultationID);
            if (detail == null)
            {
                return HttpNotFound();
            }
            else
            {
                var issueItem = typeConsultationService.GetIssueItemByID(typeConsultationID);
                InitializeTypeConsultationIssueViewBugs(issueItem);
                return View("Detail", detail);
            }
        }

        [HttpPost]
        public ActionResult ExportPDF(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        private void InitializeResidentViewBugs()
        {
            ViewBag.vbGenders = residentService.GetGenderDropDownItems();
            ViewBag.vbRegions = residentService.GetRegionDropDownItems();
            ViewBag.vbCommunities = residentService.GetCommunityDropDownItems();
        }
        private void InitializeIssueViewBugs()
        {
            ViewBag.vbIssueTypes = issueService.GetIssueTypeDropDownItems();
        }
        private void InitializeTypeConsultationViewBugs()
        {
            ViewBag.vbTargetGroups = typeConsultationService.GetTargetGroupDropDownItems();
            ViewBag.vbConsultationResults = typeConsultationService.GetConsultationResultDropDownItems();
            ViewBag.vbConsultationTypes = typeConsultationService.GetConsultationTypeDropDownItems();
            ViewBag.vbProcessStatuses = typeConsultationService.GetProcessStatusDropDownItems();
            //ViewBag.PrevUrl = Request.UrlReferrer.AbsolutePath.ToString();
        }

        private void InitializeTypeConsultationIssueViewBugs(IssueItem item)
        {
            ViewBag.ResidentID = item.ResidentID;
            ViewBag.IssueCategoryID = item.IssueCategoryID;
            ViewBag.ResidentName = item.FirstName + " " + item.MiddleName + " " + item.LastName;
            ViewBag.IdentificatorNumber = item.IdentificatorNumber;
            ViewBag.BirthDate = String.Format("{0:yyyy-MM-dd}", item.BirthDate);
            ViewBag.CompanyName = item.CompanyName;
        }

        private void InitializeAnonymousIssueViewBugs(AnonymousIssueItem item)
        {
            ViewBag.IssueCategoryID = item.IssueCategoryID;
            ViewBag.IssueName = item.IssueName;
        }
    }
}
