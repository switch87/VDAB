using MVCBierenApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBierenApplication.Services
{
    public class BierService
    {
        private static readonly Dictionary<int, Bier> bieren = new Dictionary<int, Bier>();

        static BierService()
        {
            bieren[0] =new Bier(){Alcohol = 12.5f,ID = 0,Naam = "Westmalle trippel"};
            bieren[1] = new Bier() { Alcohol = 1.2f, ID = 1, Naam = "Jupiler light" };
            bieren[2] = new Bier() { Alcohol = 15f, ID = 2, Naam = "Westmalle kwadrupple" };
            bieren[3] = new Bier() { Alcohol = 5.4f, ID = 3, Naam = "Jupiler" };
        }

        internal static object FindAll()
        {
            return bieren.Values.ToList();
        }

        internal static object Read( int id )
        {
            return bieren[id];
        }

        internal static void Delete( int id )
        {
            bieren.Remove( id );
        }
    }
}