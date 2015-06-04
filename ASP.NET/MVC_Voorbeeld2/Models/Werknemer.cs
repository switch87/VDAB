using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Voorbeeld2.Models
{
    public class Werknemer: Persoon
    {
        public decimal Wedde { get; set; }
        public DateTime Indienst { get; set; }
    }
}