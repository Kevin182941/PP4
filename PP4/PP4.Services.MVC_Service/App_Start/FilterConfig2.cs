using System.Web;
using System.Web.Mvc;

namespace PP4.Services.MVC_Service
{
    public class FilterConfig2
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
