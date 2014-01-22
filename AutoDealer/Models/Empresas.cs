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

    public partial class Empresas
    {
        public Empresas()
        {
            this.Facturas = new HashSet<Facturas>();
            this.Showrooms = new HashSet<Showrooms>();
        }

        public static List<Empresas> GetEmpresas()
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<Empresas> Lista = new List<Empresas>();
            Lista = db.Empresas.ToList();
            return Lista;
        }

        public static List<Empresas> GetEmpresa(int id)
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<Empresas> Lista = new List<Empresas>();
            Lista = db.Empresas.Where(x => x.Id == id).ToList();
            return Lista;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Nullable<int> Telefono { get; set; }
        public string Direccion { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Facturas> Facturas { get; set; }
        public virtual Status Status1 { get; set; }
        public virtual ICollection<Showrooms> Showrooms { get; set; }
    }
}