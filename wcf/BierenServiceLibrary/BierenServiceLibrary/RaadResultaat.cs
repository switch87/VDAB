using System.Runtime.Serialization;

namespace BierenServiceLibrary
{
    [DataContract]
    public class RaadResultaat
    {
        [DataMember]
        public Hint Hint { get; set; }

        [DataMember]
        public int Beurten { get; set; }
    }
}