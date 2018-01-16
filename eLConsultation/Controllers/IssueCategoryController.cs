using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    [Authorize(Roles = "administrator")]
    public class IssueCategoryController : Controller
    {
        IssueCategoryService service;

        public IssueCategoryController()
        {
            service = new IssueCategoryService();
        }

        public JsonResult IssueCategoryList()
        {
            return Json(service.GetIssueCategorys(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IssueCategorySelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetIssueCategorys().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IssueCategoryCreate([DataSourceRequest] DataSourceRequest request, IssueCategoryItem issueCategoryItem)
        {
            if (issueCategoryItem != null && ModelState.IsValid)
            {
                service.CreateIssueCategory(issueCategoryItem);
            }
            return Json(new[] { issueCategoryItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IssueCategoryUpdate([DataSourceRequest] DataSourceRequest request, IssueCategoryItem issueCategoryItem)
        {
            if (issueCategoryItem != null && ModelState.IsValid)
            {
                service.UpdateIssueCategory(issueCategoryItem);
            }
            return Json(new[] { issueCategoryItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IssueCategoryDelete([DataSourceRequest] DataSourceRequest request, IssueCategoryItem issueCategoryItem)
        {
            if (issueCategoryItem != null)
            {
                service.DeleteIssueCategory(issueCategoryItem);
            }
            return Json(new[] { issueCategoryItem }.ToDataSourceResult(request, ModelState));
        }
    }
}