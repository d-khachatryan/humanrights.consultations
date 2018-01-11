using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class CommunityController : Controller
    {
        CommunityService service;

        public CommunityController()
        {
            service = new CommunityService();
        }

        public JsonResult CommunityList()
        {
            return Json(service.GetCommunities(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CommunitySelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetCommunities().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CommunityCreate([DataSourceRequest] DataSourceRequest request, CommunityItem communityItem)
        {
            if (communityItem != null && ModelState.IsValid)
            {
                service.CreateCommunity(communityItem);
            }
            return Json(new[] { communityItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CommunityUpdate([DataSourceRequest] DataSourceRequest request, CommunityItem communityItem)
        {
            if (communityItem != null && ModelState.IsValid)
            {
                service.UpdateCommunity(communityItem);
            }
            return Json(new[] { communityItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CommunityDelete([DataSourceRequest] DataSourceRequest request, CommunityItem communityItem)
        {
            if (communityItem != null)
            {
                service.DeleteCommunity(communityItem);
            }
            return Json(new[] { communityItem }.ToDataSourceResult(request, ModelState));
        }
    }
}