using System.Collections.Generic;
using System.ServiceModel;

namespace PlantenServiceLibrary
{
    [ServiceContract]
    public interface IPlantenService
    {
        // Welke planten bestaan er met een prijs vanaf een minimum prijs
        // die de client in de request meegeeft.
        [OperationContract]
        List<Plant> PlantenMinimumprice(double minPrijsDecimal);

        // Welke planten bestaan er met een bepaald woord in hun naam.
        List<Plant> PlantenNameContains(string subString);
    }
}