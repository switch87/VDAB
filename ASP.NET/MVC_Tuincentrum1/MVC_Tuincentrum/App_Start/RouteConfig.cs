using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Tuincentrum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute("FindPlantenByPrijsBetween", "planten",
                new {controller = "Plant", action = "FindPlantenBetweenPrijzen"},
                new
                {
                    QueryConstraint = new QueryStringConstraint(
                        new[] {"minprijs", "maxprijs"})
                });

            routes.MapRoute("FindPlantenByKleur", "planten",
                new {Controller = "Plant", action = "FindPlantenVanEenKleur"},
                new
                {
                    QueryConstraint = new QueryStringConstraint(
                        new[] {"kleur"})
                });

            routes.MapRoute("Alleplanten", "Plantenlijst",
                new {controller = "Plant", action = "Index"}
                );

            routes.MapRoute("PlantByNr", "Plant/{id}",
                new {controller = "Plant", action = "Details"}
                );

            routes.MapRoute("PlantenVanEenLeverancier", "leverancier/{levnr}/planten",
                new {controller = "Plant", action = "FindPlantenByLeverancier"}
                );

            routes.MapRoute("PlantenVanEenSoort", "soort/{soortnaam}/planten",
                new {controller = "Plant", action = "FindPlantenBySoortNaam"}
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}