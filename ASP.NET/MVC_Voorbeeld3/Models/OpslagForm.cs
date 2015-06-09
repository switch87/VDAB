using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Voorbeeld3.Models
{
    public class OpslagForm
    {
        [Display( Name = "Van wedde:" )]
        [Required(ErrorMessage="Vul in in in, van aant begin, van aant begin!")]
        public decimal? VanWedde { get; set; }
        [Display(Name="Tot wedde:")]
        [Required(ErrorMessage="Moet ik het gokken of zo? Onnozel manneke!!!!")]
        public decimal? TotWedde { get; set; }
        [Display(Name="Percentage:")]
        [Required(ErrorMessage="Ik kan natuurlijk ook gewoon zelf beslissen hoeveel opslag ze krijgen...")]
        [Range(0,100,ErrorMessage="Godverdemiljaardenondedjuverdommenogaantoe!!!!, tussen {1} en {2} blijven, dat is moeilijk hé!!")]
        public decimal Percentage { get; set; }
    }
}