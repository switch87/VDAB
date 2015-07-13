using System.ServiceModel;
namespace BierenServiceLibrary
{
    [ServiceContract( Namespace = "http://vdab.be/alcoholradenservice" )]
    public interface IRadenService
    {
        [OperationContract]
        RaadResultaat RaadDuvelAlcohol( decimal alcohol );
    }
}