using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.Models.TableViewModels
{
    public class AdminTableTeacher
    {
        public int Id { get;set;}
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public int? Active { get; set; }

    }
}