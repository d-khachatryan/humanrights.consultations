using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    [Authorize(Roles = "administrator")]
    public class IssueTypeController : Controller
    {
        IssueTypeService service;

        public IssueTypeController()
        {
            service = new IssueTypeService();
        }

        public JsonResult IssueTypeList()
        {
            return Json(service.GetIssueTypes(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IssueTypeSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetIssueTypes().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IssueTypeCreate([DataSourceRequest] DataSourceRequest request, IssueTypeItem issueTypeItem)
        {
            if (issueTypeItem != null && ModelState.IsValid)
            {
                service.CreateIssueType(issueTypeItem);
            }
            return Json(new[] { issueTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IssueTypeUpdate([DataSourceRequest] DataSourceRequest request, IssueTypeItem issueTypeItem)
        {
            if (issueTypeItem != null && ModelState.IsValid)
            {
                service.UpdateIssueType(issueTypeItem);
            }
            return Json(new[] { issueTypeItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IssueTypeDelete([DataSourceRequest] DataSourceRequest request, IssueTypeItem issueTypeItem)
        {
            if (issueTypeItem != null)
            {
                service.DeleteIssueType(issueTypeItem);
            }
            return Json(new[] { issueTypeItem }.ToDataSourceResult(request, ModelState));
        }
    }
}