using System;
using System.Linq;

namespace TDDCursusLibrary
{
    public static class Statistiek
    {
        public static decimal Gemiddelde(decimal[] getallen)
        {
            if (getallen == null)
            {
                throw new ArgumentNullException();
            }
            if (getallen.Length == 0)
            {
                throw new ArgumentException();
            }
            var totaal = getallen.Sum();
            return totaal/getallen.Length;
        }
    }
}