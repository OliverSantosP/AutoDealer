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

    public partial class Colores
    {
        public Colores()
        {
            this.Automoviles = new HashSet<Automoviles>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual ICollection<Automoviles> Automoviles { get; set; }
        public virtual Status Status1 { get; set; }

        /// <summary>
        /// Retorna una lista de colores activos.
        /// </summary>
        /// <returns>Lista de Colores.</returns>
        public static List<Colores> GetColors()
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<Colores> ListaColores = new List<Colores>();
            ListaColores = db.Colores.Where(x => x.Status == 1).ToList();
            return ListaColores;
        }

        /// <summary>
        /// Retorna una lista de colores activos usando un Id.
        /// </summary>
        /// <returns>Lista de Colores.</returns>
        public static Colores GetColor(int Id)
        {
            AutoDealerEntities db = new AutoDealerEntities();
            Colores ListaColores = new Colores();
            ListaColores = db.Colores.Where(x => x.ID == Id).FirstOrDefault();
            return ListaColores;
        }
    
    }
}
