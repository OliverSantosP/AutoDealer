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
        public static List<TiposRoles> GetTiposRoles()
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<TiposRoles> ListaTiposRoles = new List<TiposRoles>();
            ListaTiposRoles = db.TiposRoles.ToList();
            return ListaTiposRoles;
        }


        public static List<TiposRoles> ConseguirRolesDePersona(int Id)
        {
            AutoDealerEntities db = new AutoDealerEntities();

            List<PersonasRoles> ListaPersonaRoles = new List<PersonasRoles>();
            ListaPersonaRoles = db.PersonasRoles.Where(x => x.Persona == Id).ToList();

            List<TiposRoles> ListaTiposRoles = new List<TiposRoles>();

            foreach (var item in ListaPersonaRoles)
            {
                ListaTiposRoles = db.TiposRoles.Where(y => y.Status == 1).ToList();
                ListaTiposRoles = ListaTiposRoles.Where(z => z.Id == item.Rol).ToList();
            }

            return ListaTiposRoles;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Status { get; set; }

        public virtual Status Status1 { get; set; }
        public virtual ICollection<PersonasRoles> PersonasRoles { get; set; }
    }
}
