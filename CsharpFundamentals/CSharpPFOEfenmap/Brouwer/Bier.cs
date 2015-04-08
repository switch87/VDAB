using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brouwers_linq
{
    public class Bier
    {
        public int BierNr { get; set; }
        public string Biernaam { get; set; }
        public float Alcohol { get; set; }
        public Brouwer Brouwer { get; set; }
        public override string ToString()
        {
            return Biernaam+": " + Alcohol + "% alcohol";
        }
    }
}
