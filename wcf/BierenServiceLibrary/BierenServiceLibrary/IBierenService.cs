using System.Collections.Generic;
using System.ServiceModel;

namespace BierenServiceLibrary
{
    [ServiceContract(Namespace = "http://vdab.be/bierenservice")]
    public interface IBierenService
    {
        [OperationContract]
        int GetTotaalAantalBieren();

        [OperationContract]
        int GetAantalBierenTussenAlcohol(decimal van, decimal tot);

        [OperationContract]
        List<Bier> GetBierenMetWoord(string woord);
    }
}