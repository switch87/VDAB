using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVC_Tuincentrum
{
    public class QueryStringConstraint : IRouteConstraint
    {
        private readonly string[] _verwachteParametersStrings;

        public QueryStringConstraint(string[] verwachteParametersStrings)
        {
            _verwachteParametersStrings = verwachteParametersStrings;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return _verwachteParametersStrings.All(verwachteParameter =>
                httpContext.Request.QueryString.AllKeys.
                    Contains(verwachteParameter, StringComparer.OrdinalIgnoreCase));
        }
    }
}