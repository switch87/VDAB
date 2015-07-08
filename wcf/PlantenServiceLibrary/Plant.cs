using System.Runtime.Serialization;

namespace PlantenServiceLibrary
{
    [DataContract]
    public class Plant
    {
        [DataMember]
        public double Prijs { get; set; }

        [DataMember]
        public int Nummer { get; set; }

        [DataMember]
        public string Naam { get; set; }
    }
}