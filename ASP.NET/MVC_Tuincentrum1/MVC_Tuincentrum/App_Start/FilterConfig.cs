using System.Web.Mvc;
using MVC_Tuincentrum.Filters;

namespace MVC_Tuincentrum
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new StatistiekActionFilter());
        }
    }
}