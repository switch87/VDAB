using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Tuincentrum1.Models
{
    public class ZoekSoortForm
    {
        [Display( Name = "Begin soortnaam:" )]
        [Required( ErrorMessage = "Verplicht" )]
        public string beginNaam { get; set; }

        public List<Soort> Soorten { get; set; }
    }
}