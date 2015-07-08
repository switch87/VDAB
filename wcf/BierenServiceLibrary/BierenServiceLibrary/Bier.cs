using System.Runtime.Serialization;

namespace BierenServiceLibrary
{
    [DataContract]
    public class Bier
    {
        [DataMember]
        public int BierNr { get; set; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public decimal Alcohol { get; set; }
    }
}