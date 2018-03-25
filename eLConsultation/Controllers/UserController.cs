using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using eLConsultation.Data;

namespace eLConsultation.Controllers
{
    [Authorize(Roles = "administrator")]
    public class UserController : Controller
    {

        UserService userService;

        public UserController()
        {
            userService = new UserService();
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
            return View();
        }

        public ActionResult SelectUsers([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<IdentityUserItem> users = userService.SelectUsers();
            DataSourceResult result = users.ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult InitInsertUser()
        {
            try
            {
                var item = userService.InitInsert();
                if (item == null)
                {
                    return this.ErrorHandler(null);
                }
                return View("InsertUser", item);
            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }
        }

        [HttpPost]
        public ActionResult InsertUser(UserItem userItem)
        {
            try
            {
                int result = userService.Insert(userItem, HttpContext.GetOwinContext(), Request);

                if (result == 1)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("error", userService.ErrorMessage);
                    return View("InsertUser", userItem);
                }
            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }
        }

        public ActionResult InitUpdateUser(string Id)
        {
            try
            {
                var item = userService.InitUpdate(Id);
                if (item != null)
                {
                    return View("UpdateUser", item);
                }
                else
                {
                    return this.ErrorHandler(userService.ServiceException);
                }

            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }
        }

        [HttpPost]
        public ActionResult UpdateUser(UpdateUserItem updateUserItem)
        {
            try
            {
                var result = userService.Update(updateUserItem, HttpContext.GetOwinContext());
                if (result == 1)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("error", userService.ErrorMessage);
                    return View("UpdateUser", updateUserItem);
                }
            }
            catch (Exception ex)
            {
                return this.ErrorHandler(ex);
            }
        }

        public ActionResult DeleteUser(string Id)
        {
            try
            {
                int result = userService.Delete(Id, HttpContext.GetOwinContext());
                if (result == 1)
                {
                    return Json("DELETE_SUCCESS", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("DELETE_FAILED", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}