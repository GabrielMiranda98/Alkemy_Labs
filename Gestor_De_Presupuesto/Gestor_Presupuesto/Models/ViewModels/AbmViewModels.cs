using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Gestor_Presupuesto.Models.ViewModels
{
    public class AbmViewModels
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Concept")]
        public string Concept { get; set; }

        public int Amount { get; set; }

        public int IdType { get; set; }
        public int Operations_registered { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

    }

}