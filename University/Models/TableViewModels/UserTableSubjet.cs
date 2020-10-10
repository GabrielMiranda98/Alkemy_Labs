using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.Models.TableViewModels
{
    public class UserTableSubjet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Time { get; set; }
        public int? Teacher { get; set; }
        public int? MaxStudent { get; set; }
        public string Info { get; set; }

        
    }
}