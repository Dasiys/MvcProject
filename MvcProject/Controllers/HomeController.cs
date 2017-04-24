using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpGet]
        public ActionResult Test()
        {
            ViewBag.Title = "Test Page";
            ViewBag.Model = "Test";
            return View();
        }

        public ActionResult TestMethod()
        {
            ViewBag.Model = "ModelModelModel";
            return View();
        }
    }
}
