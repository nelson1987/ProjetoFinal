using System.Web.Mvc;
using System.Xml.XPath;

namespace Ephesto.Web.ActionFilters
{
    public class LogCabecalhoFilters : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            LogarNavegacaoUsuario(actionExecutedContext);
            this.OnActionExecuted(actionExecutedContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogarNavegacaoUsuario(filterContext);
            this.OnActionExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext resultExecutedContext)
        {
            LogarNavegacaoUsuario(resultExecutedContext);
            this.OnResultExecuted(resultExecutedContext);
        }
        public override void OnResultExecuting(ResultExecutingContext resultExecutingContext)
        {
            LogarNavegacaoUsuario(resultExecutingContext);
            this.OnResultExecuting(resultExecutingContext);
        }

        private static void LogarNavegacaoUsuario(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.HttpContext.Request.IsAjaxRequest())
            {
                var result = actionExecutedContext.Result as ViewResultBase;
                if (result != null && result.Model != null)
                {
                    actionExecutedContext.Result = new JsonResult
                    {
                        Data = result.Model,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }
            var Controller = actionExecutedContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = actionExecutedContext.ActionDescriptor.ActionName + " (Logged By: Custom Action Filter)";
            var IP = actionExecutedContext.HttpContext.Request.UserHostAddress;
            var DateTime = actionExecutedContext.HttpContext.Timestamp;
        }

        private static void LogarNavegacaoUsuario(ResultExecutedContext resultExecutedContext)
        {
            //var Controller = resultExecutedContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //var Action = resultExecutedContext.ActionDescriptor.ActionName + " (Logged By: Custom Action Filter)";
            var IP = resultExecutedContext.HttpContext.Request.UserHostAddress;
            var DateTime = resultExecutedContext.HttpContext.Timestamp;
        }

        private static void LogarNavegacaoUsuario(ResultExecutingContext resultExecutingContext)
        {
            //var Controller = resultExecutingContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //var Action = resultExecutingContext.ActionDescriptor.ActionName + " (Logged By: Custom Action Filter)";
            var IP = resultExecutingContext.HttpContext.Request.UserHostAddress;
            var DateTime = resultExecutingContext.HttpContext.Timestamp;
        }

        private static void LogarNavegacaoUsuario(ActionExecutingContext filterContext)
        {
            // Log Action Filter Call
            //MusicStoreEntities storeDB = new MusicStoreEntities();
            //
            //ActionLog log = new ActionLog()
            //{
            var Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = filterContext.ActionDescriptor.ActionName + " (Logged By: Custom Action Filter)";
            var IP = filterContext.HttpContext.Request.UserHostAddress;
            var Browser = filterContext.HttpContext.Request.Browser.Browser;
            var DateTime = filterContext.HttpContext.Timestamp;
            //};
            //
            //storeDB.ActionLogs.Add(log);
            //storeDB.SaveChanges();
        }
    }
}