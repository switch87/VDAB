using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenOpdracht;

namespace UnitTestProject1
{
    [TestClass]
    public class PersoonTest
    {
        [TestMethod]
        [ExpectedException( typeof( Exception ), "Persoon heeft mindstens 1 voornaam" )]
        public void IederePersoonHeeftMinstensEenVoornaam()
        {
            Persoon persoon = new Persoon( new List<string>() );
        }

        [TestMethod]
        public void EenPersoonKanGeenTweeKeerDezelfdeVoornaamHebben()
        {
            Persoon persoon = new Persoon(new List<string>(){"Gert","Gert","Johan"});
            Assert.AreEqual(1, ((persoon.ToString().Split(' ')).Where(naam => naam.Equals("Gert"))).Count() );
        }

        [TestMethod]
        [ExpectedException( typeof( Exception ), "Iedere voornaam moet mindstens 1 teken bevatten" )]
        public void IedereVoornaamMoetMindstensEenTekenBevatten()
        {
            Persoon persoon = new Persoon( new List<string>() {"  "} );
        }

        [TestMethod]
        public void ToStringGeeftEenStringTerugVanAlleVoornamenGescheidenDoorEenSpatie()
        {
            string voornamen = "Gert John Louis";
            List<string> voornamenList = new List<string>(){"Gert","John","Louis"};
            Assert.AreEqual(voornamen, new Persoon(voornamenList).ToString());
        }
    }
}
