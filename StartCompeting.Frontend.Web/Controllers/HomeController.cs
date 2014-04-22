using System.Web.Helpers;
using System.Web.Mvc;
using Core.Interfaces;
using Core.Models;

namespace StartCompeting.Frontend.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            string msg = "";
            var users = _userService.GetAllUsersByUserName("Jesper");

            foreach (var user in users)
            {
                msg += user.Username + ", ";
            }

            ViewBag.Message = msg;

            return View();
        }

        public JsonResult Users()
        {
            var users = _userService.GetAllUsersByUserName("123");
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
