using System;
using System.Net;
using Ephesto.Web.ActionResults;
using Ephesto.Domain.Entities;
using Ephesto.Domain.Interfaces.Service;
using System.Web.Mvc;
using System.Web.Security;
using Ephesto.Web.ActionFilters;
using Ephesto.Web.JsonResults;

namespace Ephesto.Web.Controllers
{
    [LogCabecalhoFilters]
    public class BaseController : Controller
    {
        [Obsolete("Não use JSON, use JsonSuccess")]
        protected JsonResult Json<T>(T data)
        {
            throw new InvalidOperationException("Não use JSON, use JsonSuccess");
        }

        protected PadraoJsonResult JsonSuccess()
        {
            return new PadraoJsonResult();
        }

        protected PadraoJsonResult JsonError()
        {
            var retornoJson = new PadraoJsonResult() {};
            retornoJson.Status = HttpStatusCode.InternalServerError;
            return retornoJson;
        }

        protected PadraoJsonResult JsonSuccess(Object Data)
        {
            return new PadraoJsonResult() { Data = Data };
        }

    }
    public class HomeController : BaseController
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

        public ActionResult DetalharUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var perfilProcurado = new Perfil(1, "Novos");
            var usuarios = _usuarioService.ListarPorPerfil(perfilProcurado);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        [HttpPost]
        public ActionResult ListarJson(string uf)
        {
            var perfilProcurado = new Perfil(1, "Novos");
            var usuarios = _usuarioService.ListarPorPerfil(perfilProcurado);
            return JsonSuccess(usuarios);
        }

        public PadraoJsonResult ListarJson()
        {
            try
            {
                var perfilProcurado = new Perfil(1, "Novos");
                var usuarios = _usuarioService.ListarPorPerfil(perfilProcurado);
                return JsonSuccess(usuarios);
            }
            catch (Exception ex)
            {
                return JsonError();
            }
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
            return new LogoutAction(redirect);
        }
    }
}