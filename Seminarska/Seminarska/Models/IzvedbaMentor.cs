//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seminarska.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IzvedbaMentor
    {
        public int Izvedba { get; set; }
        public int Mentor { get; set; }
        public string brezveze { get; set; }
    
        public virtual Izvedba Izvedba1 { get; set; }
        public virtual Mentor Mentor1 { get; set; }
    }
}
