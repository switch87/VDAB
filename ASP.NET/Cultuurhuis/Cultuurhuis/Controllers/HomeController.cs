using System.Web.Mvc;
using Cultuurhuis.Models;
using Cultuurhuis.Services;

namespace Cultuurhuis.Controllers
{
    public class HomeController : Controller
    {
        private readonly CultuurService db = new CultuurService();

        public ActionResult Index(int? id)
        {
            var voorstellingenInfo = new VoorstellingenInfo
            {
                GenreList = db.GetAllGenres(),
                VoorstellingList = db.GetAllVoorstellingenOfGenre(id),
                Genre = db.GetGenre(id)
            };
            return View(voorstellingenInfo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Reserveren(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}