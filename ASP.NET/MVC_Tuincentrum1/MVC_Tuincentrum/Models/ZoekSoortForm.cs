using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Tuincentrum.Models
{
    public class ZoekSoortForm
    {
        [Display(Name = "Begin soortnaam:")]
        [Required(ErrorMessage = "Verplicht")]
        public string beginNaam { get; set; }

        public List<Soort> Soorten { get; set; }
    }
}