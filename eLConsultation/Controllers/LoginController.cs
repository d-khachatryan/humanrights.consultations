using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using eLConsultation.Data;

namespace eLConsultation.Controllers
{
    [Authorize(Roles = "administrator, writer, reader, reportspecialist")]
    public class LoginController : Controller
    {
        UserService userComponent;

        public LoginController()
        {
            userComponent = new UserService();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginItem model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await userComponent.Login(HttpContext.GetOwinContext(), Request, model);
                switch (result)
                {
                    case LoginStatus.Success:
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    case LoginStatus.RequireConfirmation:
                        HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        return View("DisplayEmail");
                    case LoginStatus.LockedOut:
                        return View("Lockout");
                    case LoginStatus.Failure:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);
                    case LoginStatus.SystemFailure:
                        ModelState.AddModelError("", userComponent.ServiceException.Message);
                        return View(model);
                    default:
                        ModelState.AddModelError("", "Unknown error");
                        return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [AllowAnonymous]
        [ValidateInput(false)]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await HttpContext.GetOwinContext().GetUserManager<InstanceUserManager>().ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordItem model)
        {
            if (ModelState.IsValid)
            {
                var result = await userComponent.ForgotPassword(HttpContext.GetOwinContext(), Request, model);
                switch (result)
                {
                    case 0:
                        return View("ForgotPasswordConfirmation");
                    case 1:
                        return RedirectToAction("ForgotPasswordConfirmation", "Login");
                    case -1:
                        return View(model);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View("ResetPassword");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordItem model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userComponent.ResetPassword(HttpContext.GetOwinContext(), Request, model);
            switch (result)
            {
                case 0:
                    return RedirectToAction("ResetPasswordConfirmation", "Login");
                case 1:
                    return RedirectToAction("ResetPasswordConfirmation", "Login");
                case 2:
                    ModelState.AddModelError("error", userComponent.ErrorMessage);
                    return View();
                case -1:
                    return View(model);
                default:
                    return View();
            }
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Login");
        }

        [AllowAnonymous]
        public ActionResult Lockout()
        {
            return View();
        }
    }
}