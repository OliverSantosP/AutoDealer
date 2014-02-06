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
    
    public partial class Gastos
    {
        public Gastos()
        {
            this.Liquidaciones = new HashSet<Liquidaciones>();
        }

        public static bool TieneGastos(string AutomovilId)
        {
            AutoDealerEntities db = new AutoDealerEntities();

            bool Existe;
            Existe = false;
            int AutomovilIdInt = Int32.Parse(AutomovilId);
            List<Gastos> ListaGastos = new List<Gastos>();
            ListaGastos = db.Gastos.Where(x => x.Automovil == AutomovilIdInt).ToList();
            if (ListaGastos.Count > 0)
            {
                return Existe = true;
            }

            return Existe = false;
        }

        public static List<Gastos> GetGastosOf(string AutomovilId)
        {
            int AutomovilIdInt = Int32.Parse(AutomovilId);
            AutoDealerEntities db = new AutoDealerEntities();
            List<Gastos> ListaGastos = new List<Gastos>();
            ListaGastos = (from a in db.Gastos where a.Automovil == AutomovilIdInt select a).ToList();
            return ListaGastos;
        }

        public static int TotalGastos(string AutomovilId)
        {
            int AutomovilIdInt = Int32.Parse(AutomovilId);
            AutoDealerEntities db = new AutoDealerEntities();
            int Total = (from a in db.Gastos where a.Automovil == AutomovilIdInt select a.Precio).Sum();
            return Total;
        }

        public static int TotalGastos(DateTime Desde, DateTime Hasta)
        {
            AutoDealerEntities db = new AutoDealerEntities();
            int Total = 0;
            try
            {
                Total = (from a in db.Gastos where (a.FechaCreacion >= Desde && a.FechaCreacion <= Hasta) select a.Precio).Sum();
            }
            catch (Exception)
            {
                Total = 0;
            }
            
            return Total;
        }
    
        public int Id { get; set; }
        public int Tipo { get; set; }
        public int Precio { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int Automovil { get; set; }
        public string PagadoA { get; set; }
    
        public virtual TiposDeGastos TiposDeGastos { get; set; }
        public virtual ICollection<Liquidaciones> Liquidaciones { get; set; }
    }
}
