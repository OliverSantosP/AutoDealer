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

    public partial class Personas
    {
        public Personas()
        {
            this.Facturas = new HashSet<Facturas>();
            this.Facturas1 = new HashSet<Facturas>();
            this.Liquidaciones = new HashSet<Liquidaciones>();
            this.Liquidaciones1 = new HashSet<Liquidaciones>();
            this.PersonasRoles = new HashSet<PersonasRoles>();
        }

        public static List<Personas> GetSuplidores()
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<Personas> ListaPersonas = new List<Personas>();


            List<PersonasRoles> ListaPersonasRoles = new List<PersonasRoles>();
            ListaPersonasRoles = db.PersonasRoles.Where(x => x.Rol == 3).ToList();

            foreach (var item in ListaPersonasRoles)
            {
                Personas Personita = new Personas();
                Personita = db.Personas.Where(x => x.Id == item.Persona).First();
                ListaPersonas.Add(Personita);
            }
            return ListaPersonas;
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int Status { get; set; }
    
        public virtual ICollection<Facturas> Facturas { get; set; }
        public virtual ICollection<Facturas> Facturas1 { get; set; }
        public virtual ICollection<Liquidaciones> Liquidaciones { get; set; }
        public virtual ICollection<Liquidaciones> Liquidaciones1 { get; set; }
        public virtual ICollection<PersonasRoles> PersonasRoles { get; set; }
    }
}
