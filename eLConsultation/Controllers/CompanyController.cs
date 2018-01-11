using eLConsultation.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using System.Linq;

using System.Web.Mvc;


namespace eLConsultation.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class CompanyController : Controller
    {
        CompanyService service;

        public CompanyController()
        {
            service = new CompanyService();
        }

        public JsonResult CompanyList()
        {
            return Json(service.GetCompanys(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterCompanys([DataSourceRequest]DataSourceRequest request, string companyName)
        {
            ViewBag.ScreenWidth = Request.Browser.ScreenPixelsWidth;
            var companySearch = new CompanySearch { CompanyName = companyName};
            Session["companySearch"] = companySearch;
            DataSourceResult result = service.SearchCompanySetItems(companySearch).ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanySelect([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetCompanys().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyCreate([DataSourceRequest] DataSourceRequest request, CompanyItem companyItem)
        {
            if (companyItem != null && ModelState.IsValid)
            {
                service.CreateCompany(companyItem);
            }
            return Json(new[] { companyItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyUpdate([DataSourceRequest] DataSourceRequest request, CompanyItem companyItem)
        {
            if (companyItem != null && ModelState.IsValid)
            {
                service.UpdateCompany(companyItem);
            }
            return Json(new[] { companyItem }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyDelete([DataSourceRequest] DataSourceRequest request, CompanyItem companyItem)
        {
            if (companyItem != null)
            {
                service.DeleteCompany(companyItem);
            }
            return Json(new[] { companyItem }.ToDataSourceResult(request, ModelState));
        }
    }
}