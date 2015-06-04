using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCursusLibrary
{
    public class Woord
    {
        private string woord;

        public Woord(string woord)
        {
            this.woord = woord;
        }


        public bool IsPalindroom()
        {
            return new string(woord.ToArray().Reverse().ToArray()).Equals(woord);
        }
    }
}
