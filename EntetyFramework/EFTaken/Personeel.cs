//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFTaken
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personeel
    {
        public Personeel()
        {
            this.Personeel1 = new HashSet<Personeel>();
        }
    
        public int PersoneelsNr { get; set; }
        public string Voornaam { get; set; }
        public Nullable<int> ManagerNr { get; set; }
    
        public virtual ICollection<Personeel> Personeel1 { get; set; }
        public virtual Personeel Personeel2 { get; set; }
    }
}