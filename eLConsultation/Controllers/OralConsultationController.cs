using eLConsultation.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Web.Mvc;

namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator,writer")]
    public class OralConsultationController : BaseController
    {
        private OralConsultationService oralConsultationService;
        private ResidentService residentService;
        private IssueService issueService;

        public OralConsultationController()
            : base()
        {
            oralConsultationService = new OralConsultationService();
            residentService = new ResidentService();
            issueService = new IssueService();
        }

        public ActionResult Index()
        {
            var oralConsultationSearch = new OralConsultationSearch();
            if (Session["oralConsultationSearch"] != null)
            {
                oralConsultationSearch = (OralConsultationSearch)Session["oralConsultationSearch"];
            }
            if (Request.Browser.IsMobileDevice)
            {
                return View("MobileIndex", oralConsultationSearch);
            }

            return View(oralConsultationSearch);
        }

        public ActionResult FilterOralConsultations([DataSourceRequest]DataSourceRequest request, string firstName, string lastName, DateTime? oralconsultationdate, int? oralconsultationid)
        {
            var oralConsultationSearch = new OralConsultationSearch { FirstName = firstName, LastName = lastName, OralConsultationDate = oralconsultationdate, OralConsultationID = oralconsultationid };
            Session["oralConsultationSearch"] = oralConsultationSearch;
            DataSourceResult result = oralConsultationService.FilterOralConsultations(oralConsultationSearch).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Dispatcher()
        {
            var residentSearch = new ResidentSearch();
            return View("Dispatcher", residentSearch);
        }

        public ActionResult IssueDispatcher()
        {
            var issueSearch = new IssueSearch();
            return View("IssueDispatcher", issueSearch);
        }

        public ActionResult Resident(int? residentID = null)
        {
            var item = residentService.GetResidentItem();
            InitializeResidentViewBugs();
            return View("Resident", item);
        }        

        public ActionResult Issue(int residentID)
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

        public ActionResult InitOralConsultation(int issueID)
        {
            InitializeOralConsultationViewBugs();
            var issueItem = issueService.GetIssueItemByID(issueID);
            InitializeOralConsultationIssueViewBugs(issueItem);
            var item = oralConsultationService.GetOralConsultationItemByIssueID(issueID);
            return View("OralConsultation", item);
        }

        public ActionResult UpdateOralConsultation(int oralConsultationID)
        {
            InitializeOralConsultationViewBugs();
            var item = oralConsultationService.GetOralConsultationItemByID(oralConsultationID);
            return View("OralConsultation", item);
        }

        [HttpPost]
        public ActionResult SaveResident(ResidentItem item)
        {
            if (ModelState.IsValid)
            {
                item = residentService.SaveResident(item);
                InitializeIssueViewBugs();
                return RedirectToAction("Issue", new { residentID = item.ResidentID });
            }
            else
            {
                InitializeResidentViewBugs();
                return View("Resident", item);
            }
        }

        [HttpPost]
        public ActionResult SaveIssue(IssueItem item)
        {
            if (ModelState.IsValid)
            {
                item = issueService.SaveIssue(item);
                InitializeOralConsultationViewBugs();
                return RedirectToAction("InitOralConsultation", new { issueID = item.IssueID });
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
                InitializeOralConsultationViewBugs();
                InitializeAnonymousIssueViewBugs(item);
                return RedirectToAction("InitOralConsultation", new { issueID = item.IssueID });
            }
            else
            {
                InitializeIssueViewBugs();
                return View("AnonymousIssue", item);
            }
        }

        [HttpPost]
        public ActionResult SaveOralConsultation(OralConsultationItem item)
        {
            if (ModelState.IsValid)
            {
                item.UserID = signedUserID;

                OralConsultationItem resultItem = oralConsultationService.SaveOralConsultation(item);

                if (resultItem != null)
                {
                    return RedirectToAction("Index", "OralConsultation");
                }
                else
                {
                    InitializeOralConsultationViewBugs();
                    ModelState.AddModelError("error", oralConsultationService.ServiceException.Message);
                    return View("OralConsultation", item);
                }
            }
            else
            {
                InitializeOralConsultationViewBugs();
                return View("OralConsultation", item);
            }
        }

        public ActionResult DeleteOralConsultation([DataSourceRequest]DataSourceRequest request, int oralConsultationID)
        {
            try
            {
                var item = oralConsultationService.DeleteOralConsultation(oralConsultationID);
                if (item == false)
                {
                    return Json("No record in the database with the OralConsultationID provided", JsonRequestBehavior.AllowGet);
                }
                if (item == null)
                {
                    return Json(oralConsultationService.ServiceException.Message, JsonRequestBehavior.AllowGet);
                }
                return Json("DELETE_SUCCESS", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int oralConsultationID)
        {
            using (var db = new StoreContext())
            {
                OralConsultationDetail detail = oralConsultationService.GetOralConsultationDetail(oralConsultationID);
                if (detail == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Detail", detail);
                }
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
        private void InitializeOralConsultationViewBugs()
        {
            ViewBag.vbTargetGroups = oralConsultationService.GetTargetGroupDropDownItems();
            ViewBag.vbInvocationTypes = oralConsultationService.GetInvocationTypeDropDownItems();
            ViewBag.PrevUrl = Request.UrlReferrer.AbsolutePath.ToString();
        }

        private void InitializeOralConsultationIssueViewBugs(IssueItem item)
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
