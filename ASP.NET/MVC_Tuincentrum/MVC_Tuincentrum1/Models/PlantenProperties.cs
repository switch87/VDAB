using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Tuincentrum1.Models
{
    public class PlantenProperties
    {
        [Range( 0, 1000 )]
        public decimal VerkoopPrijs { get; set; }
    }
}