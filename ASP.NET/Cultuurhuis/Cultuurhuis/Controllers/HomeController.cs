using System;
using System.Collections.Generic;
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
            var gekozenVoorstelling = db.GetVoorstelling(id);
            return View(gekozenVoorstelling);
        }

        [HttpPost]
        public ActionResult Reserveer(int id)
        {
            var aantalPlaatsen = uint.Parse(Request["aantalPlaatsen"]);
            var voorstellingInfo = db.GetVoorstelling(id);
            if (aantalPlaatsen > voorstellingInfo.VrijePlaatsen)
            {
                return RedirectToAction("Reserveer", "Home", new {id});
            }
            Session[id.ToString()] = aantalPlaatsen;
            return RedirectToAction("Mandje", "Home");
        }

        public ActionResult Mandje()
        {
            decimal teBetalen = 0;
            var mandjeItems = new List<MandjeItem>();
            foreach (string nummer in Session)
            {
                int voorstellingsnummer;
                if (!int.TryParse(nummer, out voorstellingsnummer)) continue;
                var voorstelling = db.GetVoorstelling(voorstellingsnummer);
                if (voorstelling == null) continue;
                var mandjeItem = new MandjeItem(voorstellingsnummer, voorstelling.Titel,
                    voorstelling.Uitvoerders, voorstelling.Datum, voorstelling.Prijs,
                    Convert.ToInt16(Session[nummer]));
                teBetalen += (mandjeItem.Plaatsen*mandjeItem.Prijs);
                mandjeItems.Add(mandjeItem);
            }
            ViewBag.teBetalen = teBetalen;
            return View(mandjeItems);
        }
    }
}