using System;
using System.Text.RegularExpressions;

namespace TDDCursusLibrary
{
    public class Rekeningnummer
    {
        private static readonly Regex regex = new Regex("^\\d{3}-\\d{7}-\\d{2}$");
        private readonly string nummer;

        public Rekeningnummer(string nummer)
        {
            if (!regex.IsMatch(nummer)) 
            {
                throw new ArgumentException();
            }
            var eerste10Cijfers = long.Parse(nummer.Substring(0, 3) + nummer.Substring(4, 7));
            var laatste2Cijfers = long.Parse(nummer.Substring(12, 2));
            if (eerste10Cijfers%97L != laatste2Cijfers)
            {
                throw new ArgumentException();
            }
            this.nummer = nummer;
        }


        public override string ToString()
        {
            return nummer;
        }
    }
}