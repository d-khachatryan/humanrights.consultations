using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Controllers
{
    public abstract partial class BaseController : Controller
    {
        protected string signedUserID;

        public BaseController()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                signedUserID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, 
                ControllerContext.RouteData.Values["controller"].ToString(),
                        ControllerContext.RouteData.Values["action"].ToString());

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}