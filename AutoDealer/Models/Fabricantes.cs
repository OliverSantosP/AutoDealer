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
    
    public partial class Fabricantes
    {
        public Fabricantes()
        {
            this.TiposAutomoviles = new HashSet<TiposAutomoviles>();
        }
        public static List<Fabricantes> GetFabricantes()
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<Fabricantes> Lista = new List<Fabricantes>();
            Lista = db.Fabricantes.ToList();
            return Lista;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Status { get; set; }
    
        public virtual Status Status1 { get; set; }
        public virtual ICollection<TiposAutomoviles> TiposAutomoviles { get; set; }
    }
}
