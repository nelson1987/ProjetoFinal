using System.Reflection;
using Ephesto.Crosscutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ephesto.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            IoC.Bootstraper(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
            
        }
    }
}
