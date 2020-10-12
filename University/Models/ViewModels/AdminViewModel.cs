using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models.ViewModels
{
    public class AdminViewModel
    { 
        [Required]
        [Display(Name = "User of administrator")]
        public string User { get; set; }
        [Required]
        [Display(Name = "Password of administrator")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password have't equal")]
        public string ConfirmPassword { get; set; }
        public int IdTeacher { get; set; }

    }
}

