using MVC_Voorbeeld3.Models;
using MVC_Voorbeeld3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{
    public class PersoonController:Controller
    {
        private PersoonService persoonService = new PersoonService();
        public ActionResult Index()
        {
            return View( persoonService.FindAll() );
        }

        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View( persoonService.FindByID( id ) );
        }

        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            persoonService.Delete( id );
            return RedirectToAction( "Index" );
        }

        public ActionResult Opslag()
        {
            OpslagForm opslagForm = new OpslagForm();
            opslagForm.Percentage = 10;
            return View( opslagForm );
        }

        [HttpPost]
        public ActionResult Opslag(OpslagForm opslagForm) {
            if ( this.ModelState.IsValid )
            {
                persoonService.Opslag( opslagForm.VanWedde.Value, opslagForm.TotWedde.Value, opslagForm.Percentage );
                return RedirectToAction( "Index" ); 
            }
            else
            {
                return View( opslagForm );
            }
        }
    }
}