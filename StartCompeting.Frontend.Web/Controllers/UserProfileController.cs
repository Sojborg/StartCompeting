using System.Web.Mvc;

namespace StartCompeting.Frontend.Web.Controllers
{
    public class UserProfileController : Controller
    {
        public UserProfileController()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}