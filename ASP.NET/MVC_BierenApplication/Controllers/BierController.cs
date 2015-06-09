using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBierenApplication.Models;
using MVCBierenApplication.Services;

namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
        // GET: Bier
        public ActionResult Index()
        {
            var bieren = BierService.FindAll();
            
            return View(bieren);
        }

        public ActionResult Verwijder( int id )
        {
            var bier = BierService.Read( id );
            return View( bier );
        }

        [HttpPost]
        public ActionResult Delete( int id )
        {
            var bier = BierService.Read( id );
            this.TempData["bier"] = bier;
            BierService.Delete( id );
            return Redirect( "~/Bier/Verwijderd" );
        }

        public ActionResult Verwijderd()
        {
            var bier = (Bier)this.TempData["bier"];
            return View( bier );
        }

        [HttpGet]
        public ActionResult Toevoegen()
        {
            var bier = new Bier() { Alcohol = 5.0f };
            return View( bier );
        }
         
        [HttpPost]
        public ActionResult Toevoegen(Bier bier)
        {
            if ( this.ModelState.IsValid )
            {
                BierService.Add( bier );
                return RedirectToAction( "Index" );
            }
            return View( bier );
        }
    }
}