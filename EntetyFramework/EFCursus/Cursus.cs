//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFCursus
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class Cursus
    {
        public int CursusNr { get; set; }
        public string Naam { get; set; }
        public Nullable<System.DateTime> Van { get; set; }
        public Nullable<System.DateTime> Tot { get; set; }
        public Nullable<int> Duurtijd { get; set; }
        public string SoortCursus { get; set; }
    }
}
