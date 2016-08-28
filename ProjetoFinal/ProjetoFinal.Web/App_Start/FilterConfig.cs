using System.Web.Mvc;
using Ephesto.Web.ActionFilters;

namespace Ephesto.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogCabecalhoFilters());
        }
    }
}
