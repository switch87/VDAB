using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class StatistiekTest
    {
        [TestMethod]
        public void HetGemiddeldeVan10en15is12punt5()
        {
            decimal[] getallen = {10m, 15m};
            Assert.AreEqual(12.5m, Statistiek.Gemiddelde(getallen));
        }

        [TestMethod]
        public void HetGemiddeldeVanEenGetalIsDatGetal()
        {
            var enigGetal = 1.23m;
            decimal[] getallen = {enigGetal};
            Assert.AreEqual(enigGetal, Statistiek.Gemiddelde(getallen));
        }

        [TestMethod, ExpectedException(typeof (ArgumentException))]
        public void hetGemiddeldeVanEenLegeVerzamelingKanJeNietBerekenen()
        {
            decimal[] legeVerzameling = {};
            Statistiek.Gemiddelde(legeVerzameling);
        }

        [TestMethod, ExpectedException(typeof (ArgumentNullException))]
        public void HetGemiddeldeVanNullKanJeNietBerekenen()
        {
            Statistiek.Gemiddelde(null);
        }
    }
}