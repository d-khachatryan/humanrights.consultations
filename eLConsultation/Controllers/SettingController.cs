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
    [Authorize(Roles = "administrator")]
    public class SettingController : Controller
    {
        [NonAction]
        private ViewResult ErrorHandler(Exception ex)
        {
            return View("Error", new HandleErrorInfo(ex,
                        this.ControllerContext.RouteData.Values["controller"].ToString(),
                        this.ControllerContext.RouteData.Values["action"].ToString()));
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SmtpSetting()
        {

            var smtpSettingService = new SmtpSettingService();
            var smtpSettings = smtpSettingService.GetSmtpSetting();
            return View("SmtpSetting", smtpSettings);

        }

        [HttpPost]
        public ActionResult SaveSmtpSetting(SmtpSetting smtpSetting)
        {

            var smtpSettingService = new SmtpSettingService();
            try
            {
                smtpSettingService.SetSmtpSetting(smtpSetting);
                return View("SmtpSettingSuccessful");
            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }

        }
    }
}