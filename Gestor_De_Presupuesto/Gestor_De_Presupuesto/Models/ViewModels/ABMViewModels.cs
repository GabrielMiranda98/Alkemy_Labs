using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Gestor_De_Presupuesto.Models.ViewModels
{
    public class ABMViewModels
    {
        public int Id { get; set; }
        public string Concept { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public int Operations_registered { get; set; }
    }
}