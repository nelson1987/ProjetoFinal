using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;

namespace Ephesto.Web.Controllers
{
    public class FaceController : Controller
    {
        // GET: Face
        public ActionResult Index()
        {
            ViewBag.UrlFb = GetFacebookLoginUrl();
            return View();
        }
        public string GetFacebookLoginUrl()
        {
            var mapeamento = Server.MapPath("~");
            dynamic parameters = new ExpandoObject();
            parameters.client_id = "282342138587721";
            parameters.redirect_uri = "http://localhost:65443/face/retornofb";
            parameters.response_type = "code";
            parameters.display = "page";

            const string extendedPermissions = "user_about_me";//",read_stream,publish_stream";
            parameters.scope = extendedPermissions;

            var _fb = new FacebookClient();
            var url = _fb.GetLoginUrl(parameters);

            return url.ToString();
        }
        public ActionResult RetornoFb()
        {
            var _fb = new FacebookClient();
            FacebookOAuthResult oauthResult;

            _fb.TryParseOAuthCallbackUrl(Request.Url, out oauthResult);

            if (oauthResult.IsSuccess)
            {
                //Pega o Access Token "permanente"
                dynamic parameters = new ExpandoObject();
                parameters.client_id = "282342138587721";
                parameters.redirect_uri = "http://localhost:65443/face/retornofb";
                parameters.client_secret = "f67fbb3bce8b6f7071c16247be045eb4";
                parameters.code = oauthResult.Code;

                dynamic result = _fb.Get("/oauth/access_token", parameters);

                var accessToken = result.access_token;

                //TODO: Guardar no banco
                Session.Add("FbUserToken", accessToken);
            }
            else
            {
                // tratar
            }

            return RedirectToAction("Index");
        }
        public ActionResult DetalhesDoUsuario()
        {
            if (Session["FbuserToken"] != null)
            {
                var _fb = new FacebookClient(Session["FbuserToken"].ToString());

                //detalhes do usuario
                var request = _fb.Get("me");
                var a = request;
            }

            return RedirectToAction("Index");
        }
        public ActionResult ListarAmigos()
        {
            if (Session["FbuserToken"] != null)
            {
                var _fb = new FacebookClient(Session["FbuserToken"].ToString());

                //listar os amigos
                var request = _fb.Get("me/friends");
                var a = request;
            }

            return RedirectToAction("Index");

        }
        public ActionResult PublicarMensagem()
        {
            if (Session["FbuserToken"] != null)
            {
                var _fb = new FacebookClient(Session["FbuserToken"].ToString());

                //Postar uma mensagem na timeline
                dynamic messagePost = new ExpandoObject();
                messagePost.picture = "http://www.rodolfofadino.com.br/wp-content/uploads/2013/12/image_thumb10.png";
                messagePost.link = "http://www.rodolfofadino.com.br/2013/12/test-mode-values-para-o-microsoft-advertising-sdk-windows-8/";
                messagePost.name = "Post name...";
                messagePost.caption = " Post Caption";
                messagePost.description = "post description";
                messagePost.message = "Mensagem de testes da aplicação";

                try
                {
                    var postId = _fb.Post("me/feed", messagePost);
                }
                catch (FacebookOAuthException ex)
                {
                    //handle oauth exception
                }
                catch (FacebookApiException ex)
                {
                    //handle facebook exception
                }
            }

            return RedirectToAction("Index");
        }
    }
}