using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVC_Tuincentrum.Filters;
using MVC_Tuincentrum.Models;

namespace MVC_Tuincentrum.Controllers
{
    [StatistiekActionFilter] //Statistiek bijhouden van alle paginas met betrekking tot deze controller
    public class PlantController : Controller
    {
        private readonly MVCTuinCentrumEntities db = new MVCTuinCentrumEntities();

        public ActionResult FindPlantenBetweenPrijzen(decimal minPrijs, decimal maxPrijs)
        {
            var plantenLijst = new List<Plant>();
            plantenLijst = (from plant in db.Planten
                where plant.VerkoopPrijs >= minPrijs && plant.VerkoopPrijs <= maxPrijs
                select plant).ToList();
            ViewBag.minprijs = minPrijs;
            ViewBag.maxprijs = maxPrijs;
            return View(plantenLijst);
        }

        public ActionResult FindPlantenVanEenKleur(string kleur)
        {
            var plantenLijst = new List<Plant>();
            plantenLijst = (from plant in db.Planten
                where plant.Kleur == kleur
                select plant).ToList();
            ViewBag.kleur = kleur;
            return View(plantenLijst);
        }

        public ActionResult FindPlantenByLeverancier(int? levnr)
        {
            var plantenLijst = new List<Plant>();
            plantenLijst = (from plant in db.Planten.Include("Leveranciers")
                where plant.Leveranciers.LevNr == levnr
                select plant).ToList();
            return View(plantenLijst);
        }

        public ActionResult FindPlantenBySoortNaam(string soortnaam)
        {
            var plantenLijst = new List<Plant>();
            plantenLijst = (from plant in db.Planten.Include("Soorten")
                where plant.Soorten.Naam.StartsWith(soortnaam)
                select plant).ToList();
            return View(plantenLijst);
        }

        // GET: Plant
        public ActionResult Index()
        {
            var planten = db.Planten.Include(p => p.Leveranciers).Include(p => p.Soorten);
            return View(planten.ToList());
        }

        // GET: Plant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plant = db.Planten.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // GET: Plant/Create
        public ActionResult Create()
        {
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam");
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam");
            return View();
        }

        // POST: Plant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Planten.Add(plant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // GET: Plant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plant = db.Planten.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // POST: Plant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantNr,Naam,SoortNr,Levnr,Kleur,VerkoopPrijs")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Levnr = new SelectList(db.Leveranciers, "LevNr", "Naam", plant.Levnr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam", plant.SoortNr);
            return View(plant);
        }

        // GET: Plant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plant = db.Planten.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var plant = db.Planten.Find(id);
            db.Planten.Remove(plant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Plant/Uploaden/5
        public ViewResult Uploaden(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult FotoUpload(int id)
        {
            if (Request.Files.Count <= 0) 
                return RedirectToAction("Index");
            var foto = Request.Files[0];
            var absoluutPadNaarDir = HttpContext.Server.MapPath("~/Images/Fotos");
            var absoluutPadNaarFoto = Path.Combine(absoluutPadNaarDir, id + ".jpg");
            foto.SaveAs(absoluutPadNaarFoto);
            return RedirectToAction("Index");
        }

        [Route("plantinfo/{id:int}")]
        public ActionResult FindPlantById(int id)
        {
            var plant = db.Planten.Find(id);
            if (plant != null)
                return View("Details", plant);
            var planten = db.Planten.Include(p => p.Leveranciers).Include(p => p.Soorten);
            return View("Index", planten.ToList());
        }

        [Route("plantinfo/{naam}")]
        public ActionResult FindPlantByName(string naam)
        {
            var plant = (from p in db.Planten
                where p.Naam == naam
                select p).FirstOrDefault();
            if (plant != null)
                return View("Details", plant);
            var planten = db.Planten.Include(p => p.Leveranciers).Include(p => p.Soorten);
            return View("Index", planten.ToList());
        }

        [Route( "plantenprijzen/{btw:values(inclusief|exclusief)}", Name = "btwinex" )]
        public ActionResult PrijsLijst(string btw)
        {
            ViewBag.Btw = btw; 
            return View( db.Planten.ToList() );
        }
    }
}