using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_Tuincentrum.Filters
{
    public class StatistiekActionFilter : ActionFilterAttribute
    {
        private static readonly Dictionary<string, int> _statistiek = new Dictionary<string, int>();

        public static Dictionary<string, int> Statistiek
        {
            get { return _statistiek; }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var url = filterContext.HttpContext.Request.Url.ToString();
            lock (_statistiek)
            {
                if (_statistiek.ContainsKey(url))

                    _statistiek[url]++;
                else
                    _statistiek[url] = 1;
            }
        }
    }
}