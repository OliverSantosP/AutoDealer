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

    public partial class TiposRoles
    {
        public TiposRoles()
        {
            this.PersonasRoles = new HashSet<PersonasRoles>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Status { get; set; }
    
        public virtual ICollection<PersonasRoles> PersonasRoles { get; set; }
        public virtual Status Status1 { get; set; }

        public static List<TiposRoles> GetTiposRoles()
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<TiposRoles> ListaTiposRoles = new List<TiposRoles>();
            ListaTiposRoles = db.TiposRoles.ToList();
            return ListaTiposRoles;
        }

        public static string ConseguirNombreRol(int Id)
        {
            AutoDealerEntities db = new AutoDealerEntities();
            TiposRoles TipoRol = new TiposRoles();
            string Nombre;
            TipoRol = db.TiposRoles.Where(x => x.Id == Id).FirstOrDefault();
            Nombre = TipoRol.Nombre;
            return Nombre;
        }



    }
}
