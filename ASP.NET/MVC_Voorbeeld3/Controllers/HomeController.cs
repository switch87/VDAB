using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string resultaat = "Dit is jouw eerste bezoek";
            //zijn er cookies?
            if ( Request.Cookies != null )
            {
                if ( Request.Cookies["lastvisit"] != null )
                {
                    //dan lezen we het tijdstip van het laatste bezoek uit de cookie
                    resultaat = "Welkom terug. Jouw laatste bezoek was op " + Request.Cookies["lastvisit"]["tijdstip"];
                }

                //we slaan het huidige tijdstip op als laatste bezoek
                string laatsteBezoek = DateTime.Now.ToString();
                var userCookie = new HttpCookie( "lastvisit" );
                userCookie["tijdstip"] = laatsteBezoek;
                userCookie["taal"] = Request.UserLanguages[0];
                userCookie.Expires = DateTime.Now.AddDays( 365 );
                Response.Cookies.Add( userCookie );
            }

            //sessionvariabele aanpassen
            if ( this.Session["aantalBezoeken"] == null )
                this.Session["aantalBezoeken"] = 1;
            else
            this.Session["aantalBezoeken"] = (int)this.Session["aantalBezoeken"] + 1;

            //applicationvariabele aanpassen
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] =
                (int)System.Web.HttpContext.Current.Application["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();

            resultaat +=  ". Jouw voorkeurtaal is " + Request.Cookies["lastvisit"]["taal"]
                        + " Dit is trouwens al je " + this.Session["aantalBezoeken"] + "e sessiebezoek, niets beters te doen misschien?"
                        + " In totaal bezocht je deze saaie pagina ook al " + System.Web.HttpContext.Current.Application["aantalBezoeken"] + " keer...";
            ViewBag.Tijdstip = resultaat;

            return View();
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

        public ActionResult Wissen()
        {
            //zijn er cookies?
            if ( Request.Cookies != null )
            {
                //is er een cookie met de naam "lastvisit"?
                if ( Request.Cookies["lastvisit"] != null )
                {
                    Request.Cookies["lastvisit"].Expires = DateTime.Now.AddDays( -1 );
                    Response.Cookies.Add( Request.Cookies["lastvisit"] );
                }
            }
            if ( this.Session["aantalBezoeken"] != null ) this.Session["aantalBezoeken"] = null;
            return View();
        }

    }
}