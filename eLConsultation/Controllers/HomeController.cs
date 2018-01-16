using eLConsultation.Data;
using System.Web;
using System.Web.Mvc;

namespace eLConsultation.Controllers
{

    public class HomeController : Controller
    {
        string administratorRole = "administrator";
        SettingService settingService;
        SmtpSettingService smtpSettingService;
        UserService userService;

        public HomeController()
        {
            settingService = new SettingService();
            userService = new UserService();
            smtpSettingService = new SmtpSettingService();
        }

        public ActionResult Start()
        {

            if (userService.IsUserInRole(administratorRole))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Configure", "Home");
            }
        }

        [Authorize]
        public ActionResult Index()
        {

            if (userService.IsUserInRole(administratorRole))
            {
                return View("Index");
            }
            else
            {
                return View("Configure");
            }

        }

        public ActionResult Configure()
        {

            if (userService.IsUserInRole(administratorRole))
            {
                return View("Index");
            }
            else
            {
                Configure config = new Configure();
                return View("Configure", config);
            }
        }

        [HttpPost]
        public ActionResult Configure(Configure configure)
        {

            var userItem = userService.InitInsert();
            
            userItem.UserName = configure.User_UserName;
            userItem.FirstName = configure.User_FirstName;
            userItem.LastName = configure.User_LastName;
            userItem.Email = configure.User_Email;
            userItem.Password = configure.User_Password;
            userItem.ConfirmPassword = configure.User_ConfirmPassword;

            userItem.UserItemSelectedRoles.Add(administratorRole);
            int result = userService.Insert(userItem, HttpContext.GetOwinContext(), Request);

            if (result == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("error", userService.ErrorMessage);
                return View("Configure", configure);
            }

        }

        public ActionResult UnderConstruction()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Version()
        {
            ViewBag.Version = settingService.GetSettingByItem("version").SettingValue;
            return PartialView();
        }
    }
}