using System.Web.Mvc;

namespace Ephesto.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Data = "Teste";

            return View();
        }
    }
}
