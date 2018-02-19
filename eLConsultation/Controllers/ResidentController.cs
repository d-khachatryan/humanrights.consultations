using eLConsultation.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator,writer")]
    public class ResidentController : Controller
    {
        StoreContext db;
        ResidentService service;

        public ResidentController()
        {
            db = new StoreContext();
            service = new ResidentService();
        }

        [NonAction]
        private ViewResult ErrorHandler(Exception ex)
        {
            return View("Error", new HandleErrorInfo(ex,
                        this.ControllerContext.RouteData.Values["controller"].ToString(),
                        this.ControllerContext.RouteData.Values["action"].ToString()));
        }

        public ActionResult Index()
        {
            var residentSearch = new ResidentSearch();
            if (Session["residentSearch"] != null)
            {
                residentSearch = (ResidentSearch)Session["residentSearch"];
            }
            if (Request.Browser.IsMobileDevice)
            {
                return View("IndexMobile", residentSearch);
            }
            return View(residentSearch);
        }

        public ActionResult FilterResidents([DataSourceRequest]DataSourceRequest request, string firstName, string lastName)
        {
            ViewBag.ScreenWidth = Request.Browser.ScreenPixelsWidth;
            var residentSearch = new ResidentSearch { FirstName = firstName, LastName = lastName };
            Session["residentSearch"] = residentSearch;
            DataSourceResult result = service.SearchResidentSetItems(residentSearch).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Consultation(string consultationType)
        {
            try
            {
                ViewBag.ConsultationType = consultationType;
                var residentSearch = new ResidentSearch();
                return View("SelectResidentItem", residentSearch);
            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }
        }

                public ActionResult ResidentTemplate(int? residentID = null)
        {
            OrganizeViewBugs(db);
            try
            {
                var item = service.GetResidentItem();
                if (item == null)
                {
                    return this.ErrorHandler(service.ServiceException);
                }
                return View("Template", item);
            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }
        }

        public ActionResult InitResidentTemplateByResidentID(int residentID)
        {
            OrganizeViewBugs(db);
            try
            {
                var item = service.GetResidentItem(residentID);
                if (item == null)
                {
                    return this.ErrorHandler(service.ServiceException);
                }
                return View("Template", item);
            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }
        }

        [HttpPost]
        public ActionResult SaveResident(ResidentItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item = service.SaveResident(item);

                    //if (item.ResidentDestinationType == ResidentDestinationTypes.ResidentList)
                    //{
                    //    //Simply go to Rresident
                    return RedirectToAction("Index", "Resident");
                    //}
                    //else
                    //{
                    //    //Go to Issue data enty to continue wisard
                    //    return RedirectToAction("Template", "Issue", new { residentID = item.ResidentID, consultationType = item.ConsultationType });
                    //}
                }
                else
                {
                    return View("Template", item);
                }
            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }
        }

        public ActionResult DeleteResident([DataSourceRequest]DataSourceRequest request, int residentID)
        {
            try
            {
                var item = service.DeleteResident(residentID);
                if (item == false)
                {
                    return Json("No record in the database with the ResidentID provided", JsonRequestBehavior.AllowGet);
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

        public ActionResult GetOralConsultationsByResidentID([DataSourceRequest] DataSourceRequest request, int residentID)
        {
            DataSourceResult result = service.GetOralConsultationsByResidentID(residentID).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult GetTypeConsultationsByResidentID([DataSourceRequest] DataSourceRequest request, int residentID)
        {
            DataSourceResult result = service.GetTypeConsultationsByResidentID(residentID).ToDataSourceResult(request);
            return Json(result);
        }

        private void OrganizeViewBugs(StoreContext db)
        {
            var lGenders = new List<SelectListItem>();
            lGenders = db.Genders.Select(x => new SelectListItem { Text = x.GenderName, Value = x.GenderID.ToString() }).ToList();
            ViewBag.vbGenders = lGenders;

            var lRegions = new List<SelectListItem>();
            lRegions = db.Regions.Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionID.ToString() }).ToList();
            ViewBag.vbRegions = lRegions;

            var lCommunities = new List<SelectListItem>();
            lCommunities = db.Communities.Select(x => new SelectListItem { Text = x.CommunityName, Value = x.CommunityID.ToString() }).ToList();
            ViewBag.vbCommunities = lCommunities;
        }
    }
}