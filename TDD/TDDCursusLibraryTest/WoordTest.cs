using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class WoordTest
    {
        [TestMethod]
        public void EenWoordDatOmgekeerdHetzelfdeIsISEenPalindroom()
        {
            Assert.IsTrue(new Woord("mam").IsPalindroom());
        }

        [TestMethod]
        public void EenWoordDatOmgekeerdAndersIsIsGeenPalindroom()
        {
            Assert.IsFalse(new Woord("biboeba").IsPalindroom());
        }

    }
}
