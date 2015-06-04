using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class JaarTest
    {
        [TestMethod]
        public void EenJaarDeelbaarDoor400IsEenSchrikkeljaar()
        {
            Assert.AreEqual(true, new Jaar(2000).IsSchrikkeljaar);
        }

        [TestMethod]
        public void EenJaarDeelbaarDoor100IsGeenSchrikkeljaar()
        {
            Assert.AreEqual(false, new Jaar(1900).IsSchrikkeljaar);
        }

        [TestMethod]
        public void EenJaarDeelbaarDoor4IsEenSchrikkeljaar()
        {
            Assert.AreEqual(true, new Jaar(2012).IsSchrikkeljaar);
        }

        [TestMethod]
        public void EenJaarNietDeelbaarDoor4IsGeenSchrikkeljaar()
        {
            Assert.AreEqual(false, new Jaar(2015).IsSchrikkeljaar);
        }
    }
}