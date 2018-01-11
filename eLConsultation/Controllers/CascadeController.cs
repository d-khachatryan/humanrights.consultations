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
    public class CascadeController : Controller
    {
       //=========== Regions and Communities ===========
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