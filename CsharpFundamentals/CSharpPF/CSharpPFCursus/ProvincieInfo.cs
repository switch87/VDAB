using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class ProvincieInfo
    {
        public int ProvincieGrootte(string provincieNaam)
        {
            StreamReader lezen = new StreamReader(@"C:\Users\net04\Documents\Visual Studio 2013\Projects\CSharpPF\CSharpPFCursus\provincies.txt");
            try
            {
                string regel;
                while ((regel = lezen.ReadLine()) != null)
                {
                    int dubbelPuntPos = regel.IndexOf(':');
                    string provincie = regel.Substring(0, dubbelPuntPos);
                    if (provincie == provincieNaam)
                        return int.Parse(regel.Substring(dubbelPuntPos + 1));
                }
            }
            finally
            {
                lezen.Close();
            }
            throw new Exception("Onbestaande provincie:" + provincieNaam);
        }
    }
}
