using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cultuurhuis.Models
{
    public class VoorstellingProperties
    {
        [DisplayFormat( DataFormatString = "{0:dd/MM/yy HH:mm}" )] 
        public System.DateTime Datum { get; set; } [DisplayFormat( DataFormatString = "{0:€ #,##0.00}" )] 
        public decimal Prijs { get; set; } 
        public short VrijePlaatsen { get; set; }
    }
}