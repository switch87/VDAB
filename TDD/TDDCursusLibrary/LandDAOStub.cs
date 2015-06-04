using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    public class LandDAOStub : ILandDAO
    {
        public Land Read(string landcode)
        {
            return new Land {Landcode = landcode, Oppervlakte = 5};
        }

        public int OppervlakteAlleLanden()
        {
            return 20;
        }
    }
}