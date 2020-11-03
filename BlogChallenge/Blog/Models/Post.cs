using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Categoria { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public byte[] Imagen { get; set; }

    }
}