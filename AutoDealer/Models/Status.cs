//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoDealer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Status
    {
        public Status()
        {
            this.Automoviles = new HashSet<Automoviles>();
            this.Fabricantes = new HashSet<Fabricantes>();
            this.Modelos = new HashSet<Modelos>();
            this.Trim = new HashSet<Trim>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Automoviles> Automoviles { get; set; }
        public virtual ICollection<Fabricantes> Fabricantes { get; set; }
        public virtual ICollection<Modelos> Modelos { get; set; }
        public virtual ICollection<Trim> Trim { get; set; }
    }
}
