﻿using MVC_Tuincentrum1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Tuincentrum1.Services
{
    public class SoortService
    {
        public List<Soort> FindByBeginNaam( string beginNaam )
        {
            using ( var db = new MVCTuinCentrumEntities() )
            {
                var query = from soort in db.Soorten
                            where soort.Naam.StartsWith( beginNaam )
                            orderby soort.Naam
                            select soort;
                var soorten = query.ToList();
                return soorten;
            }
        }
    }
}