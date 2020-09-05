using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_De_Presupuesto.Models.ViewModels
{
    public class ABMViewModels
    {
        public int id { get; set; }
        public string concept { get; set; }
        public float amount { get; set; }
        public DateTime date { get; set; }
        public int type { get; set; }
        public int operations_registered { get; set; }
    }
}