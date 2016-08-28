using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ephesto.Web.ActionResults
{
    public class LogoutAction : ActionResult
    {
        public RedirectToRouteResult ActionAfterLogout
        {
            get;
            set;
        }
        public LogoutAction(RedirectToRouteResult actionAfterLogout)
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