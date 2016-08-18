using System.Web;
using System.Web.Mvc;

namespace MVC_WEBAPI_DOCUMENTATION_PRO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
