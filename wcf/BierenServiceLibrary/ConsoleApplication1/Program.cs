using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BierenServiceLibrary;

namespace ConsoleBierenServiceHost
{
    class Program
    {
        static void Main( string[] args )
        {
            using (var serviceHost = new ServiceHost(typeof (BierenService)))
            {
                serviceHost.Open();
                Console.WriteLine("Druk s om de service te stoppen");
                while (Console.ReadLine()!="s")
                {
                }
            }
        }
    }
}
