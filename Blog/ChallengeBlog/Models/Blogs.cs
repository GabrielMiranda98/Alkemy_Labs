using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeBlog.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Categoria { get; set; }
        public DateTime fechaDeCreacion { get; set; }

    }
}