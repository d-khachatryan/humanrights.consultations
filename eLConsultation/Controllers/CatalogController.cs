using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace eLConsultation.Controllers
{
    public class CatalogController : Controller
    {
        public JsonResult GenderList()
        {
            using (var db = new StoreContext())
            {
                var q = db.Genders.Select(c => new { Value = c.GenderID, Text = c.GenderName }).ToList();
                return Json(q, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CommunityList()
        {
            using (var db = new StoreContext())
            {
                var q = db.Communities.Select(c => new { Value = c.CommunityID, Text = c.CommunityName }).ToList();
                return Json(q, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Gender()
        {
            return View();
        }

        public ActionResult GenderSelect([DataSourceRequest] DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IList<Gender> result = new List<Gender>();

                result = db.Genders.ToList();
                return Json(result.ToDataSourceResult(request));
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GenderInsert([DataSourceRequest] DataSourceRequest request, Gender gender)
        {
            if (gender != null && ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new Gender();
                    entity.GenderName = gender.GenderName;
                    db.Genders.Add(entity);
                    db.SaveChanges();
                    gender.GenderID = entity.GenderID;
                }
            }
            return Json(new[] { gender }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GenderUpdate([DataSourceRequest] DataSourceRequest request, Gender gender)
        {
            if (gender != null && ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new Gender();
                    entity.GenderID = gender.GenderID;
                    entity.GenderName = gender.GenderName;
                    db.Genders.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(new[] { gender }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GenderDelete([DataSourceRequest] DataSourceRequest request, Gender gender)
        {
            if (gender != null)
            {
                using (var db = new StoreContext())
                {
                    var entity = new Gender();
                    entity.GenderID = gender.GenderID;
                    db.Genders.Attach(entity);
                    db.Genders.Remove(entity);
                    db.SaveChanges();
                }
            }
            return Json(new[] { gender }.ToDataSourceResult(request, ModelState));
        }



        //=========== Cascades ===========
        public JsonResult GetCascadeRegions()
        {
            using (var db = new StoreContext())
            {
                var q = db.Regions.Select(c => new { Value = c.RegionID, Text = c.RegionName }).ToList();
                return Json(q, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCascadeCommunities(int? regions, string CommunityFilter)
        {
            var db = new StoreContext();
            var communities = db.Communities.AsQueryable();

            if (regions != null)
            {
                communities = communities.Where(p => p.RegionID == regions);
            }

            if (!string.IsNullOrEmpty(CommunityFilter))
            {
                communities = communities.Where(p => p.CommunityName.Contains(CommunityFilter));
            }

            return Json(communities.Select(p => new { Value = p.CommunityID, Text = p.CommunityName }), JsonRequestBehavior.AllowGet);
        }

    }
}