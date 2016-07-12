using System.Web.Mvc;
using ProjetoFinal.Domain.Entities;
using ProjetoFinal.Domain.Interfaces.Service;

namespace ProjetoFinal.Web.Controllers
{
    public class HomeController : Controller
    {

        //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
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
    }
}