using System.Web.Mvc;

namespace MVC_Tuincentrum.Controllers
{
    [RoutePrefix( "Thuis" )]
    [Route( "{action=index}" )]
    public class HomeController : Controller
    {
        //[Route]
        public ActionResult Index()
        {
            return View();
        }

        //[Route("Over")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[Route( "Contacteer" )]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}