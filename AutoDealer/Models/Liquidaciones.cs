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
    
    public partial class Liquidaciones
    {
        public Liquidaciones()
        {
            this.Automoviles = new HashSet<Automoviles>();
        }
    
        public int Id { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> MontoVenta { get; set; }
        public Nullable<int> Suplidor { get; set; }
        public Nullable<int> Comprador { get; set; }
        public string PagadoCon { get; set; }
        public string DetallesDeVenta { get; set; }
        public Nullable<int> Empresa { get; set; }
        public Nullable<int> Comision { get; set; }
        public Nullable<int> Automovil { get; set; }
    
        public virtual ICollection<Automoviles> Automoviles { get; set; }
        public virtual Automoviles Automoviles1 { get; set; }
        public virtual Empresas Empresas { get; set; }
        public virtual Personas Personas { get; set; }
        public virtual Personas Personas1 { get; set; }
    }
}
