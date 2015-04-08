using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    interface IVerblijfstype
    {
        public List<Formule> BeschikbareVerblijfsFormules
        {
            get;
        }

        public bool ToeslagSingle { get; }
        public PrijsInfo PrijsInfo { get; set; }
        public string NaamVerblijf { get; set; }
        public decimal BerekenVerblijfsPrijs(int aantalDagen, Formule gekozenFormule);
    }
}
