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
    using System.Linq;
    public partial class TiposAutomoviles
    {
        public TiposAutomoviles()
        {
            this.Automoviles = new HashSet<Automoviles>();
        }

        public int Id { get; set; }
        public int Fabricante { get; set; }
        public int Modelo { get; set; }
        public Nullable<int> Trim { get; set; }
        public int Status { get; set; }
    
        public virtual ICollection<Automoviles> Automoviles { get; set; }
        public virtual Fabricantes Fabricantes { get; set; }
        public virtual Modelos Modelos { get; set; }
        public virtual Trim Trim1 { get; set; }
    }
}
