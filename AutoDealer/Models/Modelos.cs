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
    
    public partial class Modelos
    {
        public Modelos()
        {
            this.TiposAutomoviles = new HashSet<TiposAutomoviles>();
        }
        /// <summary>
        /// Este metodo retorna un modelo, dado un fabricante.
        /// </summary>
        /// <param name="Fabricante">El Id del fabricante.</param>
        /// <returns></returns>
        public static List<Modelos> GetModelos(int Fabricante)
        {
            AutoDealerEntities db = new AutoDealerEntities();
            List<TiposAutomoviles> ListaTiposAutomoviles = new List<TiposAutomoviles>();
            ListaTiposAutomoviles = db.TiposAutomoviles.Where(x => x.Fabricante == Fabricante).ToList();

            List<Modelos> ListaModelos = new List<Modelos>();
            foreach (var item in ListaTiposAutomoviles)
            {
                ListaModelos = (db.Modelos.Where(x => x.Id == item.Modelo).ToList());
            }
            return ListaModelos;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Status { get; set; }
    
        public virtual Status Status1 { get; set; }
        public virtual ICollection<TiposAutomoviles> TiposAutomoviles { get; set; }
    }
}
