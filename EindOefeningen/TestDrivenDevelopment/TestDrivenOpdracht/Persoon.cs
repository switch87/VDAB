using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenOpdracht
{
    public class Persoon
    {
        private List<string> voornamen;

        public Persoon( List<string> voornamen )
        {
            if (voornamen.Count > 0)
            {
                this.voornamen = new List<string>();
                foreach ( var voornaam in voornamen.Where( voornaam => !this.voornamen.Contains( voornaam ) ) )
                    if (voornaam.Trim().Length > 0)
                        this.voornamen.Add( voornaam );
                    else throw new Exception("Iedere voornaam moet mindstens 1 teken bevatten");
            }
            else throw new Exception("Persoon heeft mindstens 1 voornaam");
        }

        public override string ToString()
        {
            StringBuilder voornaamStringBuilder = new StringBuilder();
            foreach (var voornaam in voornamen)
            {
                voornaamStringBuilder.Append(voornaam + " ");
            }
            return (voornaamStringBuilder.ToString()).Trim();
        }
    }
}
