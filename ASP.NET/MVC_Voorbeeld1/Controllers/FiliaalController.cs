﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld1.Controllers
{
    public class FiliaalController : Controller
    {
        public ActionResult Show()
        {
            return View();
        }

        public ActionResult Read(int? id)
        {
            return View();
        }
        // GET: Filiaal
        public ActionResult Index()
        {
            return View();
        }
    }
}