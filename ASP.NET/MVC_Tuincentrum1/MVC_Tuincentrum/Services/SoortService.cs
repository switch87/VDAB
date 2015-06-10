﻿using System.Collections.Generic;
using System.Linq;
using MVC_Tuincentrum.Models;

namespace MVC_Tuincentrum.Services
{
    public class SoortService
    {
        public List<Soort> FindByBeginNaam(string beginNaam)
        {
            using (var db = new MVCTuinCentrumEntities())
            {
                var query = from soort in db.Soorten
                    where soort.Naam.StartsWith(beginNaam)
                    orderby soort.Naam
                    select soort;
                var soorten = query.ToList();
                return soorten;
            }
        }
    }
}