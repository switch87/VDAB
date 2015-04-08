using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    public class Overuren
    {
        // 30 ---= Indexers =---

        /*
         * Indexers in een class laten toe dat je data van objecten van deze class gebruikt 
         * zoals data van een array: deze data gedragen zich als een verzameling waarvan je 
         * één element kan opvragen.
         * 
         * Indexers zijn krachtiger dan gewone arrays. Bij arrays spreek je één element 
         * uit de verzameling aan door het volgnummer (een int) van het element mee te geven. 
         * Bij indexers kan je één element uit de verzameling ook aanspreken door een 
         * sleutelwaarde (bvb. een string) mee te geven, die het element uniek identificeert 
         * in de verzameling.
         */

        private int[] overurenValue = new int[12];
        private static readonly string[] maanden =
        {"jan","feb","maa","apr","mei","jun","jul","aug","sep","okt","nov","dec"};

        public int this[int maand]
        {
            get
            {
                return overurenValue[maand];
            }
            set
            {
                overurenValue[maand] = value;
            }
        }

        public int this[string maand]
        {
            get
            {
                return overurenValue[WelkeMaand(maand)];
            }
            set
            {
                overurenValue[WelkeMaand(maand)] = value;
            }
        }

        private int WelkeMaand(string maand)
        {
            int maandNr = Array.IndexOf(maanden,maand);
            if (maandNr == -1)
                throw new IndexOutOfRangeException("Ongeldige maand: " + maand);
            return maandNr;
        }

        public int Totaal
        {
            get
            {
                int totaal = 0;
                foreach (int overuur in overurenValue)
                    totaal += overuur;
                return totaal;
            }
        }
    }
}
