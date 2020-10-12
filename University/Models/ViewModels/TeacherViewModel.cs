using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name of Teacher")]
        public string Name { get; set; }
        [Display(Name = "Surname of Teacher")]
        public string SurName { get; set; }
        [Display(Name = "Dni of Teacher")]
        public string Dni { get; set; }
        [Display(Name = "Teacher is active?")]
        public int? Active { get; set; }


    }
}
