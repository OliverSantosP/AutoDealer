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
    
    public partial class Automoviles
    {
        public int Id { get; set; }
        public int Suplidor { get; set; }
        public Nullable<int> Liquidaciones { get; set; }
        public Nullable<int> Factura { get; set; }
        public int Showroom { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public System.DateTime Year { get; set; }
        public System.DateTime FechaEntrada { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
        public int Status { get; set; }
        public int TipoAutomovil { get; set; }
        public Nullable<int> Precio { get; set; }
    
        public virtual Automoviles Automoviles1 { get; set; }
        public virtual Automoviles Automoviles2 { get; set; }
        public virtual Facturas Facturas { get; set; }
        public virtual Liquidaciones Liquidaciones1 { get; set; }
        public virtual Showrooms Showrooms { get; set; }
        public virtual Status Status1 { get; set; }
        public virtual TiposAutomoviles TiposAutomoviles { get; set; }
    }
}
