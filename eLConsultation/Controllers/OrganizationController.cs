using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class OrganizationController : Controller
    {
        OrganizationService service;

        public OrganizationController()
        {
            service = new OrganizationService();
        }

        public JsonResult OrganizationList()
        {
            return Json(service.GetOrganizations(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrganizationSelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetOrganizations().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrganizationCreate([DataSourceRequest] DataSourceRequest request, OrganizationItem organizationItem)
        {
            if (organizationItem != null && ModelState.IsValid)
            {
                service.CreateOrganization(organizationItem);
            }
            return Json(new[] { organizationItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrganizationUpdate([DataSourceRequest] DataSourceRequest request, OrganizationItem organizationItem)
        {
            if (organizationItem != null && ModelState.IsValid)
            {
                service.UpdateOrganization(organizationItem);
            }
            return Json(new[] { organizationItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrganizationDelete([DataSourceRequest] DataSourceRequest request, OrganizationItem organizationItem)
        {
            if (organizationItem != null)
            {
                service.DeleteOrganization(organizationItem);
            }
            return Json(new[] { organizationItem }.ToDataSourceResult(request, ModelState));
        }
    }
}