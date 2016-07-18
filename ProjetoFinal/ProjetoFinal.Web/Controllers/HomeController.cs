using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Service;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoFinal.Web.Controllers
{
    public class HomeController : Controller
    {
        private static IUsuarioService _usuarioService;

        public HomeController(IUsuarioService usuarioRepository)
        {
            _usuarioService = usuarioRepository;
        }

        public ActionResult Index()
        {
            var perfilProcurado = new Perfil(1, "Novos");
            var usuarios = _usuarioService.ListarPorPerfil(perfilProcurado);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            var redirect = RedirectToAction("Index", "Home");
            return new LogoutActionResult(redirect);
        }
    }
    public class LogoutActionResult : ActionResult
    {
        public RedirectToRouteResult ActionAfterLogout
        {
            get; set;
        }
        public LogoutActionResult(RedirectToRouteResult actionAfterLogout)
        {
            ActionAfterLogout = actionAfterLogout;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            FormsAuthentication.SignOut();
            ActionAfterLogout.ExecuteResult(context);
        }
    }
}