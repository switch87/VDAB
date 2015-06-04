using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;
using Moq;

namespace TDDCursusLibraryTest
{
    [TestClass]
    
    public class LandServiceTest
    {
        private Mock<ILandDAO> mockFacktory;
        private ILandDAO landDAO;
        private LandService landService;

        [TestInitialize]
        public void Initialize()
        {
            landDAO = new LandDAOStub();
            landService = new LandService(landDAO);
        }

        [TestMethod]
        public void VerhoudingOppervlakteLandTovOppervlakteAlleLanden()
        {
            Assert.AreEqual(0.25m, landService.VerhoudingOppervlakteLandTovOppervlakteAlleLanden("B"));
        }
    }
}